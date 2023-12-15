using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
   private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        // Check if the Rigidbody component exists and disable kinematic property
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

}
