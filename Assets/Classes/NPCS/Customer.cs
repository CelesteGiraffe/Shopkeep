using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<GameObject> path;
    public float moveSpeed = 2f;
    private int currentWaypointIndex = 0;
    public LayerMask ObsLayer;
    private bool isMoving = false;
    private bool isInteracting = false; 
    private Rigidbody2D rb;
    public Dialogue dialogue;
    private Vector2 currentTargetPosition; 

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (path.Count > 0)
        {
            Debug.Log("Starting to follow path.");
            StartCoroutine(FollowPath());
        }
    }

    public virtual void Interact()
    {
        isInteracting = true; 
        dialogue.StartDialogue(new string[] { "Interacting with a customer.", "Goodbye!" }, EndInteraction);
    }

    private void EndInteraction()
    {
        isInteracting = false; 
    }

    public IEnumerator FollowPath()
    {
        while (true)
        {
            if (!isMoving && !isInteracting && path.Count > 0)
            {
                currentTargetPosition = path[currentWaypointIndex].transform.position;
                if (!IsCharacterInFront(currentTargetPosition))
                {
                    isMoving = true;
                    yield return StartCoroutine(MoveToPosition(currentTargetPosition));
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= path.Count)
                    {
                        Debug.Log("Reached the last waypoint.");
                        yield break;
                    }
                }
            }
            yield return null;
        }
    }

    private IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        while (Vector2.Distance(rb.position, targetPosition) > 0.1f)
        {
            if (isInteracting)
            {
                isMoving = false;
                yield break;
            }
            rb.position = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        rb.position = targetPosition;
        isMoving = false;
    }

    private bool IsCharacterInFront(Vector2 targetPosition)
    {
        Collider2D hit = Physics2D.OverlapCircle(targetPosition, 0.5f);
        return hit != null;
    }
}
