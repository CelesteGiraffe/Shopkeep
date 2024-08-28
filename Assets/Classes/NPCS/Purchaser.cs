using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchaser : Customer
{
    public override void Interact()
    {
        dialogue.StartDialogue(new string[] { "Got any grapes?", "Goodbye!" });
    }
}
