using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wind : MonoBehaviour
{
    public Vector3 direction;
    private Rigidbody rb;
    public float forceMagnitude = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().AddForce(direction);
        if (Input.GetMouseButton(0)) // Check if the left mouse button is pressed
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y; // Set the Z coordinate

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 forceDirection = (worldPos - transform.position).normalized;

            rb.AddForce(forceDirection * forceMagnitude, ForceMode.Force);
        }
    }
}
