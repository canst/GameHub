using UnityEngine;

public class SitizenController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform[] waypoints; // Массив точек маршрута
    private int currentWaypoint; // Добавлено поле currentWaypoint

    void Start()
    {
        // Выбираем случайную точку маршрута при запуске сцены
        Transform randomWaypoint = waypoints[Random.Range(0, waypoints.Length)];
        SetDestination(randomWaypoint);
    }

    void Update()
    {
        // Двигаемся к выбранной точке маршрута
        MoveSitizen();
    }

    void MoveSitizen()
    {
        // Перемещаем "sitizen" в выбранную точку маршрута
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);

        // Если "sitizen" достиг точки маршрута, выбираем новую
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            // Выбираем новую точку маршрута
            Transform newWaypoint = GetRandomWaypoint();
            SetDestination(newWaypoint);
        }
    }

    Transform GetRandomWaypoint()
    {
        // Выбираем случайную точку маршрута
        return waypoints[Random.Range(0, waypoints.Length)];
    }

    void SetDestination(Transform destination)
    {
        // Направляем "sitizen" к новой точке маршрута
        currentWaypoint = System.Array.IndexOf(waypoints, destination);
    }
}
