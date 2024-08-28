using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gossiper : Customer
{
    public override void Interact()
    {
        base.Interact();
        dialogue.StartDialogue(new string[] { "I heard that there is a big ghost being all ghosty and stuff at the edge of town!" });
        
    }
}
