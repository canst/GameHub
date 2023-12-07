using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drift : MonoBehaviour
{

public float MoveSpeed = 100;
public float MaxSpeed = 15;
public float Drag = 0.98f;
public float SteerAngle = 20;
public float Traction = 1;

private Vector3 MoveForce;

    // Update is called once per frame
    void Update()
    {   
        
        //Move
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical")* Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //Steer
        float SteerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * SteerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);
        //drag
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        //Track
        //Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        //Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;   
    }
}
