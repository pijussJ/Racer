using UnityEngine;

public class Vehicle : MonoBehaviour
{
	public float speed = 10.0f;
	public float turnSpeed = 100.0f;
	public Rigidbody rb;
	public AudioSource engineSound;

	void Update()
	{
		print(rb.velocity.magnitude * 3.6f + " km/h");

		var speedRatio = rb.velocity.magnitude / speed;
		engineSound.pitch = 0.5f + 1.5f*speedRatio;
	}

	public void Accelerate()
	{
		rb.velocity += transform.forward * speed * Time.deltaTime;
	}

	public void Brake()
	{

	}

	public void Turn(float direction)
	{
		transform.Rotate(0, direction * turnSpeed * Time.deltaTime, 0);
	}
}