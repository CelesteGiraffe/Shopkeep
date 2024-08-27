using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchaser : Customer
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start(); 
    }

    // Update is called once per frame
    void Update()
    {
        base.Update(); 
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Purchaser: I want to buy something from your shop.");
    }
}
