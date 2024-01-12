using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float moveSpeed = 5f;
    public float minZoomDistance = 1f;
    public float maxZoomDistance = 10f;

    public float boundarySize = 20f;

    private void Update()
    {
        HandleZoom();
        HandleMovement();
    }

    private void HandleZoom()
    {
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel");
        Vector3 currentPosition = transform.position;

        // »зменение позиции камеры при приближении и отдалении колесиком мыши
        currentPosition.y -= zoomAmount * zoomSpeed;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minZoomDistance, maxZoomDistance);

        transform.position = currentPosition;
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = transform.position;

        // ѕолучение текущей позиции курсора мыши
        Vector3 mousePosition = Input.mousePosition;

        // ѕроверка границ экрана и перемещение камеры при достижении границ
        if (mousePosition.x < boundarySize)
        {
            currentPosition.x -= moveSpeed * Time.deltaTime;
        }
        else if (mousePosition.x > Screen.width - boundarySize)
        {
            currentPosition.x += moveSpeed * Time.deltaTime;
        }

        if (mousePosition.y < boundarySize)
        {
            currentPosition.z -= moveSpeed * Time.deltaTime;
        }
        else if (mousePosition.y > Screen.height - boundarySize)
        {
            currentPosition.z += moveSpeed * Time.deltaTime;
        }

        transform.position = currentPosition;
    }
}
