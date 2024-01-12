using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Color[] colors; // Массив доступных цветов
    public GameObject smallCubePrefab; // Префаб маленького куба
    public float colorChangeDelay = 3f; // Задержка перед сменой цвета (в секундах)

    private Rigidbody rb;
    private bool isFirstColorSelected = false;
    private bool canBreakCube = false;
    private float colorChangeTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverCube())
        {
            if (GetComponent<Renderer>().material.color == Color.red && canBreakCube)
            {
                BreakCube();
            }
            else
            {
                Jump();
            }
        }

        if (GetComponent<Renderer>().material.color == Color.red)
        {
            colorChangeTimer += Time.deltaTime;

            if (colorChangeTimer >= colorChangeDelay)
            {
                ChangeCubeColor();
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * 20f, ForceMode.Impulse);

        // Прокрутка кубика по случайным осям с более высокой скоростью
        float rotationSpeed = Random.Range(100f, 500f);
        rb.AddTorque(Random.onUnitSphere * rotationSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Если текущий цвет не красный, изменить цвет
            if (GetComponent<Renderer>().material.color != Color.red)
            {
                // Получение случайного цвета из массива colors
                Color randomColor = GetRandomColor();
                GetComponent<Renderer>().material.color = randomColor;
                canBreakCube = (randomColor == Color.red);
            }

            colorChangeTimer = 0f;
        }
    }

    private Color GetRandomColor()
    {
        if (!isFirstColorSelected)
        {
            isFirstColorSelected = true;
            return colors[Random.Range(1, colors.Length)];
        }
        else
        {
            return colors[Random.Range(0, colors.Length)];
        }
    }

    private void ChangeCubeColor()
    {
        Color newColor = GetRandomColor();
        GetComponent<Renderer>().material.color = newColor;
        canBreakCube = (newColor == Color.red);
        colorChangeTimer = 0f;
    }

    private void BreakCube()
    {
        if (transform.localScale.x > 1f)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * 0.5f;
                GameObject smallCube = Instantiate(smallCubePrefab, spawnPosition, Quaternion.identity);
                smallCube.transform.localScale = transform.localScale / 2f;
            }
        }

        Destroy(gameObject);
    }

    private bool IsMouseOverCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == gameObject;
        }

        return false;
    }
}
