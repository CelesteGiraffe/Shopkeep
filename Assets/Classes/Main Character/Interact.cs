using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithCustomer();
        }
    }

    private void InteractWithCustomer()
    {
        Vector2 positionInFront = playerMovement.GetPositionInFront();
        Collider2D hit = Physics2D.OverlapCircle(positionInFront, 0.5f);
        Debug.Log(hit);
        if (hit != null)
        {
            Customer customer = hit.GetComponent<Customer>();
            if (customer != null)
            {
                customer.Interact();
            }
        }
    }
}
