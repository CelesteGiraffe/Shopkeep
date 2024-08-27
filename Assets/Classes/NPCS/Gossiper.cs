using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gossiper : Customer
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Interact()
    {
        base.Interact();
        dialogue.StartDialogue(new string[] { "I heard that there is a big ghost being all ghosty and stuff at the edge of town!" });
        
    }
}
