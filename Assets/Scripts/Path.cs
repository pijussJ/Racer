using UnityEngine;

public class Path : MonoBehaviour
{
	public Transform[] waypoints;

	void Start()
	{
		waypoints = GetComponentsInChildren<Transform>();
	}

	public int GetClosestWaypoint(Vector3 position)
	{
		Transform closest = waypoints[0];
		float closestDist = Vector3.Distance(position, closest.position);
		int closestIndex = 0;

		for (int i = 1; i < waypoints.Length; i++)
		{
			 float dist = Vector3.Distance(position, waypoints[i].position);
			 if (dist < closestDist)
			 {
				 closest = waypoints[i];
				 closestDist = dist;
				 closestIndex = i;
			 }
		}

		return closestIndex;
	}

	public Vector3 GetNextWaypoint(Vector3 position)
	{
		return Vector3.zero;
	}
}