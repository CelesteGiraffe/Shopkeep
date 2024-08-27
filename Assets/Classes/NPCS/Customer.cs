using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<GameObject> path; 
    public float moveSpeed = 2f;
    public LayerMask characterLayer;
    private int currentWaypointIndex = 0;
    private bool isMoving = false;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    protected virtual void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        if (path.Count > 0)
        {
            Debug.Log("Starting to follow path.");
            StartCoroutine(FollowPath());
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with a customer.");
    }

    public IEnumerator FollowPath()
    {
        while (true)
        {
            if (!isMoving && path.Count > 0)
            {
                Vector2 targetPosition = path[currentWaypointIndex].transform.position;
                if (!IsCharacterInFront(targetPosition))
                {
                    isMoving = true;
                    yield return StartCoroutine(MoveToPosition(targetPosition));
                    currentWaypointIndex = (currentWaypointIndex + 1) % path.Count;
                }
            }
            yield return null;
        }
    }

    private IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        while ((Vector2)rb.position != targetPosition)
        {
            rb.position = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    private bool IsCharacterInFront(Vector2 targetPosition)
    {
        Collider2D hit = Physics2D.OverlapCircle(targetPosition, 0.5f);
        return hit != null;
    }
}
