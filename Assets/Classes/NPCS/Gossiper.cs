using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gossiper : Customer
{
    public override void Interact()
    {
        isInteracting = true;
        if (hasRequestFullfilled) {
            dialogue.StartDialogue(leavingSentences[0], EndInteraction);
            return;
        }
        else if (hasChosenDialogue) {
            dialogue.StartDialogue(customerDialogueSentences[dialogueIndex], EndInteraction);
            return;
        }
        else {
            dialogue.StartDialogue(customerDialogueSentences[GetRandomCustomerDialogueIndex()], EndInteraction);
        }
    }
}
