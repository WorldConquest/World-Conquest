using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public void DestructionObject()
    {
        // To destroy an object, you have to browse through its children, and disable the 'Is Kinematic' function of the Rigidbody.
        Rigidbody[] rigidbodyObject = GetComponentsInChildren<Rigidbody>(); //so we're picking up the kids 

        // And for each child we deactivate Is Kenematic 
        foreach (Rigidbody rb in rigidbodyObject)
        {
            rb.isKinematic = false;
        }
    }
}
