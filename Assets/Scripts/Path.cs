using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
	public List<Transform> waypoints;

	void Start()
	{
		waypoints = new List<Transform>(GetComponentsInChildren<Transform>());
		waypoints.RemoveAt(0);
	}

	public int GetNextIndex(int i)
	{
		 if(i >= waypoints.Count-1) return 0;
		 if(i < 0) return waypoints.Count - 1;
		 else return i + 1;
	}

	public Vector3 GetWaypointPosition(int i)
	{
		if (i < 0 || i >= waypoints.Count) return Vector3.zero;
		return waypoints[i].position;
	}

	public int GetClosestWaypoint(Vector3 position)
	{
		Transform closest = waypoints[0];
		float closestDist = Vector3.Distance(position, closest.position);
		int closestIndex = 0;

		for (int i = 1; i < waypoints.Count; i++)
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