using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    //public GameObject HourGlass; 
    public Vector3 rotate;
    public float speed;

    void Update()
    {

        transform.Rotate(rotate * Time.deltaTime * speed);
    }



}