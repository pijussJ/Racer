using UnityEngine;

public class Brains : MonoBehaviour
{
    Path path;
    Vehicle vehicle;
    public int waypointIndex;
    Vector3 nextPoint;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        path = FindObjectOfType<Path>();
        waypointIndex = path.GetClosestWaypoint(transform.position);
        nextPoint = path.GetWaypointPosition(waypointIndex);
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, nextPoint);
        Debug.DrawLine(transform.position, nextPoint,Color.red);
        if (dist < 3)
        {
            waypointIndex = path.GetNextIndex(waypointIndex);
            nextPoint = path.GetWaypointPosition(waypointIndex);
        }


        var nextPointDir = (nextPoint - transform.position).normalized;
        var dir = Vector3.SignedAngle(transform.forward, nextPointDir, Vector3.up);
        vehicle.Turn(dir);
        vehicle.Accelerate();
    }
}