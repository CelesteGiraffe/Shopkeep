using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public LayerMask obstacleLayer;
    private Animator animator;
    public float gridSize = 1f; 

    private bool isMoving = false;
    private bool isCooldown = false; 
    public float cooldownDuration = 0.2f; 
    private Vector2 targetPosition;
    private Vector2 previousPosition; 
    private Coroutine moveCoroutine; 

    public Camera mainCamera;
    public float cameraSmoothSpeed = 0.125f; 

    private Vector2 lastMoveDirection; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        targetPosition = rb.position;
    }

    private void Update()
    {
        if (!isMoving && !isCooldown)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            if (moveInput != Vector2.zero)
            {
                Vector2 potentialTarget = rb.position + moveInput * gridSize;
                if (!IsObstacle(potentialTarget))
                {
                    previousPosition = rb.position;
                    targetPosition = potentialTarget;
                    moveCoroutine = StartCoroutine(MoveToGridPosition(targetPosition));
                    lastMoveDirection = moveInput; 
                }
            }
            else
            {
               
                animator.SetFloat("IdleX", lastMoveDirection.x);
                animator.SetFloat("IdleY", lastMoveDirection.y);
            }

            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
        }

        if (mainCamera != null)
        {
            Vector3 desiredPosition = new Vector3(rb.position.x, rb.position.y, mainCamera.transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, desiredPosition, cameraSmoothSpeed);
            mainCamera.transform.position = smoothedPosition;
        }
    }


    private IEnumerator MoveToGridPosition(Vector2 target)
    {
        isMoving = true;

        while ((Vector2)rb.position != target)
        {
            rb.position = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }

    private bool IsObstacle(Vector2 target)
    {
        Collider2D hit = Physics2D.OverlapCircle(target, 0.1f, obstacleLayer);
        return hit != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & obstacleLayer) != 0)
        {
            Debug.Log("Collided with obstacle");
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                isMoving = false;
                rb.position = previousPosition;
                targetPosition = previousPosition; 
                StartCoroutine(CooldownCoroutine()); 
            }
        }
    }

    private IEnumerator CooldownCoroutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isCooldown = false;
    }

    public Vector2 GetPositionInFront()
    {
        Vector2 positionInFront = rb.position + lastMoveDirection * gridSize;
        return positionInFront;
    }
}