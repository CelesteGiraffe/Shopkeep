using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gossiper : Customer
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Interact()
    {
        base.Interact();
        // Add logic to provide information about monsters
    }
}