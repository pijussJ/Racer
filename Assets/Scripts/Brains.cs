using UnityEngine;

public class Brains : MonoBehaviour
{
    Path path;
    Vehicle vehicle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        path = FindObjectOfType<Path>();
        int waypoint = path.GetClosestWaypoint(transform.position);
        print(waypoint);
    }

    void Update()
    {
        var dir = Mathf.PerlinNoise1D(Time.time) * 2 - 1;
        vehicle.Turn(dir);
        vehicle.Accelerate();
    }
}