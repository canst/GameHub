using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation_new : MonoBehaviour
{
    public Vector3 rotate;
    public float speed;
    public Transform parent; 
    private int rotationDirection = 1; // 1 for clockwise, -1 for counter-clockwise
    public float delayBeforeDisappear = 2.0f; // Adjust this value as needed
    public float delayBetweenDisappear = 1.0f;

    void Update()
    {
        StartCoroutine(DisappearBalls());
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            //rotationDirection *= -1; // Reverse rotation direction on each click
            foreach (Transform child in parent )
            {
                child.GetComponent<Rigidbody>().useGravity = !child.GetComponent<Rigidbody>().useGravity;
            }
        }

        transform.Rotate(rotate * Time.deltaTime * speed * rotationDirection);
    }
    
    IEnumerator DisappearBalls()
    {
        yield return new WaitForSeconds(delayBeforeDisappear);

        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(false); // Make the ball disappear
            yield return new WaitForSeconds(delayBetweenDisappear);
        }
    }
}
