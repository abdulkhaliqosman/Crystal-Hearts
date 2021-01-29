using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBehaviour : InteractBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInteract() 
    {
        OnPickup();
        // delete self
    }

    public abstract void OnPickup();
}
