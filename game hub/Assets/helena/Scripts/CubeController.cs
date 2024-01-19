using UnityEngine;

namespace helena2 {

public class CubeController : MonoBehaviour
{
    private Rigidbody rb;
    private int stackCount = 0;
    private Color originalColor;
    public Color stackColor = Color.red;
    public Color yellowColor = Color.yellow;

    public GameObject giganticBall;
    private bool isGiganticBallActivated = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        originalColor = GetComponent<Renderer>().material.color;
    }

    void OnMouseDown()
    {
        if (gameObject == giganticBall)
        {
            if (!isGiganticBallActivated)
            {
                // Clicking the gigantic ball before activation
                ActivateGiganticBall();
            }
            else
            {
                // Clicking the gigantic ball after activation
                ResetEverything();
            }
        }
        else if (!isGiganticBallActivated && stackCount < 4)
        {
            // Clicking other cubes before gigantic ball activation
            rb.useGravity = true;
            stackCount++;

            if (stackCount == 3)
            {
                ChangeCubeColor(stackColor);
            }
            else if (stackCount == 4)
            {
                ChangeCubeColor(yellowColor);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") && !isGiganticBallActivated)
        {
            // When one cube hits another before gigantic ball activation
            stackCount++;

            if (stackCount == 3)
            {
                ChangeCubeColor(stackColor);
            }
            else if (stackCount == 4)
            {
                ChangeCubeColor(yellowColor);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") && !isGiganticBallActivated)
        {
            // Reset color when the cube is not in contact with another cube before gigantic ball activation
            stackCount--;

            if (stackCount < 3)
            {
                ChangeCubeColor(originalColor);
            }
        }
    }

    void ChangeCubeColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    void ActivateGiganticBall()
    {
        // Disable gravity for the gigantic ball
        rb.useGravity = false;

        // Enable gravity for all other cubes
        Rigidbody[] allCubes = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody cubeRb in allCubes)
        {
            if (cubeRb.CompareTag("Cube") && cubeRb.gameObject != giganticBall)
            {
                cubeRb.useGravity = true;

                // Reset color when the gigantic ball is activated
                ChangeCubeColor(cubeRb.gameObject, originalColor);
            }
        }

        isGiganticBallActivated = true;
    }

    void ResetEverything()
    {
        // Reset state to initial values
        isGiganticBallActivated = false;
        stackCount = 0;

        // Enable gravity for the gigantic ball
        rb.useGravity = true;

        // Disable gravity for all other cubes and reset their colors
        Rigidbody[] allCubes = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody cubeRb in allCubes)
        {
            if (cubeRb.CompareTag("Cube") && cubeRb.gameObject != giganticBall)
            {
                cubeRb.useGravity = false;
                ChangeCubeColor(cubeRb.gameObject, originalColor);
            }
        }
    }

    void ChangeCubeColor(GameObject cube, Color color)
    {
        Renderer renderer = cube.GetComponent<Renderer>();
        renderer.material.color = color;
    }
}
}

