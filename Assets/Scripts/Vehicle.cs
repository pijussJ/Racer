using UnityEngine;

public class Vehicle : MonoBehaviour
{
	public float maxSpeed;
	public float acceleration = 10.0f;
	public float turnSpeed = 100.0f;
	public Rigidbody rb;
	public AudioSource engineSound;
	public float sideDrag;
	public float drag;

	void Update()
	{
		var sideFriction = Vector3.Dot(transform.right, rb.velocity.normalized);
		rb.velocity += -transform.right * sideFriction * rb.velocity.magnitude * sideDrag * Time.deltaTime;

		var forwardFriction = Vector3.Dot(transform.forward, rb.velocity.normalized);
		rb.velocity += -transform.forward * forwardFriction * rb.velocity.magnitude * drag * Time.deltaTime;


		if (Mathf.Abs(sideFriction) > 0.3f)
		{
			print("drift");
		}


		var speedRatio = rb.velocity.magnitude / maxSpeed;
		engineSound.pitch = 0.5f + 1.5f*speedRatio;
	}

	public void Accelerate()
	{
		rb.velocity += transform.forward * acceleration * Time.deltaTime;
	}

	public void Brake()
	{

	}

	public void Turn(float direction)
	{
		transform.Rotate(0, direction * turnSpeed * Time.deltaTime, 0);
	}
}