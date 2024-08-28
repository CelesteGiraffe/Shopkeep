using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    public List<string[]> customerDialogueSentences = new List<string[]> ();
    public List<string[]> gossiperDialogueSentences;
    public List<string[]> leavingSentences;

    public bool hasChosenDialogue = false;
    public bool hasRequestFullfilled = false;
    public int dialogueIndex = 0;
    public bool isInteracting = false;

private void Awake()
    {
        //get the dialogue from the player by tag
        dialogue = GameObject.FindGameObjectWithTag("Player").GetComponent<Dialogue>();
        customerDialogueSentences.Add(new string[] { "Hello", "Goodbye" });
    }

    public virtual void Interact()
    {
        isInteracting = true; 
        if (hasRequestFullfilled) {
            dialogue.StartDialogue(leavingSentences[0], EndInteraction);
            return;
        }
        else if (hasChosenDialogue) {
            dialogue.StartDialogue(customerDialogueSentences[dialogueIndex], EndInteraction);
            return;
        } else {
            dialogue.StartDialogue(customerDialogueSentences[GetRandomCustomerDialogueIndex()], EndInteraction);
        }
    }

    public void EndInteraction()
    {
        isInteracting = false; 
    }

    private bool IsCharacterInFront(Vector2 targetPosition)
    {
        Collider2D hit = Physics2D.OverlapCircle(targetPosition, 0.5f);
        return hit != null;
    }

    public int GetRandomCustomerDialogueIndex() {
        hasChosenDialogue = true;
        dialogueIndex = Random.Range(0, customerDialogueSentences.Count);
        return dialogueIndex;
    }

    public int GetRandomGossiperDialogueIndex() {
        hasChosenDialogue = true;
        dialogueIndex = Random.Range(0, gossiperDialogueSentences.Count);
        return dialogueIndex;
    }
}
