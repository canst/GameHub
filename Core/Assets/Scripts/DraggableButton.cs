using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DraggableButton : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    public Transform targetObject; // Reference to the target object
    public string sceneToLoad; // Name of the scene to load when the button is placed on the target

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
        }
    }

    public void OnPointerDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerUp()
    {
        isDragging = false;

        // Check if the button is over the target object
        if (IsOverTarget())
        {
            // Change the scene associated with this button
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private bool IsOverTarget()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Target object not set!");
            return false;
        }

        // Check if the button is over the target object
        BoxCollider2D buttonCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D targetCollider = targetObject.GetComponent<BoxCollider2D>();

        if (buttonCollider == null || targetCollider == null)
        {
            Debug.LogWarning("Button or target object is missing a BoxCollider2D component!");
            return false;
        }

        return buttonCollider.bounds.Intersects(targetCollider.bounds);
    }
}
