using UnityEngine;

public class Vehicle : MonoBehaviour
{
	public float speed = 10.0f;
	public float turnSpeed = 100.0f;

	public void Accelerate()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	public void Brake()
	{

	}

	public void Turn(float direction)
	{
		transform.Rotate(0, direction * turnSpeed * Time.deltaTime, 0);
	}
}