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
        dialogue.StartDialogue(new string[] { "Like omg you'd never guess what I learned about you from henifer!", "She said you were not going to pilates anymore!" });

    }
}
