using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPathFinder : MonoBehaviour
{
    public List<Vector2> waypoints;
    public float moveSpeed = 2f;
    private int currentWaypointIndex = 0;
    private bool isMoving = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (waypoints.Count > 0)
        {
            //Debug.Log("Starting to follow path.");
            StartCoroutine(FollowPath());
        }
    }

    private IEnumerator FollowPath()
    {
        while (true)
        {
            if (!isMoving && waypoints.Count > 0)
            {
                Vector2 targetPosition = waypoints[currentWaypointIndex];
                isMoving = true;
                yield return StartCoroutine(MoveToPosition(targetPosition));
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    Debug.Log("Reached the last waypoint.");
                    yield break;
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

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Count == 0)
            return;

        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.DrawSphere(waypoints[i], 0.2f);
            if (i < waypoints.Count - 1)
            {
                Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
            }
        }
    }
}