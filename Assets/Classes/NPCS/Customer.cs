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
    private Rigidbody2D rb;

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
            rb.position = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        rb.position = targetPosition;
        isMoving = false;
    }

    private bool IsCharacterInFront(Vector2 targetPosition)
    {
        Collider2D hit = Physics2D.OverlapCircle(targetPosition, 0.5f);
        Debug.Log(hit);
        return hit != null;
    }
}
