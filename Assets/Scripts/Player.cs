using UnityEngine;

public class Player : MonoBehaviour
{
    Vehicle vehicle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
    }

    void Update()
    {
	    if (Input.GetKey(KeyCode.W))
	    {
		    vehicle.Accelerate();
	    }

	    if (Input.GetKey(KeyCode.S))
	    {
		    vehicle.Brake();
	    }

	   var horInput = Input.GetAxis("Horizontal");
	   if (horInput != 0)
	   {
		   vehicle.Turn(horInput);
	   }
    }
}