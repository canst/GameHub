using UnityEngine;

public class SitizenController : MonoBehaviour
{
    public float moveSpeed = 1500f;
    public WayPoint currentWaypoint; // Добавлено поле currentWaypoint
    Rigidbody rig;
    public bool log = false;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

     private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverCube())
        {
          
                Jump();
            
        }
     }

    void FixedUpdate()
    {

        Vector3 dir = (currentWaypoint.transform.position - transform.position).normalized * moveSpeed;
        rig.AddForce(dir);

        if (Vector3.Distance(transform.position, currentWaypoint.transform.position) < 5f)
        {
            currentWaypoint = currentWaypoint.GetRandomWaypoint();
        }
    }
    private void Jump()
    {
        rig.AddForce(Vector3.up * 200f, ForceMode.Impulse);

        // Adjust rotation speed as needed
        float rotationSpeed = Random.Range(100f, 500f);
        rig.AddTorque(Random.onUnitSphere * rotationSpeed, ForceMode.Impulse);
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
