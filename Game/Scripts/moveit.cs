using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveit: MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed;
    private float dirX, dirZ;

    // Start is called before the first frame update
    private void Start()
    {
        moveSpeed=3f;
        rb=GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    private void Update()
    {
        dirX=Input.GetAxis("Horizontal")* moveSpeed;
        dirZ=Input.GetAxis("Vertical")* moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity=new Vector3(dirX, rb.velocity.y, dirZ);
    }


}
