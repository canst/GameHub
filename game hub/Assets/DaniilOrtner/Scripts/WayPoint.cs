using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public WayPoint[] neighbours;
    public float size;
    public WayPoint GetRandomWaypoint() {
        return neighbours[Random.Range(0, neighbours.Length)];
    }
}
