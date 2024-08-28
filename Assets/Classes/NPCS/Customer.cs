using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, IInteractable
{
    private bool isInteracting = false; 
    public Dialogue dialogue;

    private void Awake()
    {
        //get the dialogue from the player by tag
        dialogue = GameObject.FindGameObjectWithTag("Player").GetComponent<Dialogue>();

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

    private bool IsCharacterInFront(Vector2 targetPosition)
    {
        Collider2D hit = Physics2D.OverlapCircle(targetPosition, 0.5f);
        return hit != null;
    }
}
