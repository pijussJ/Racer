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
	public bool isGrounded;
	public Transform visualsTransform;
	public float speedRatio;

	void Update()
	{
		isGrounded = Physics.Raycast( transform.position, Vector3.down,out var hit,0.6f);
		var targetAngle = Vector3.SignedAngle(Vector3.up,hit.normal, Vector3.right);

		var newAngle = Mathf.LerpAngle(visualsTransform.localEulerAngles.x, targetAngle, 0.01f);
		visualsTransform.localEulerAngles = new Vector3(newAngle, 0, 0);

		var sideFriction = Vector3.Dot(transform.right, rb.velocity.normalized);
		rb.velocity += -transform.right * sideFriction * rb.velocity.magnitude * sideDrag * Time.deltaTime;

		var forwardFriction = Vector3.Dot(transform.forward, rb.velocity.normalized);
		rb.velocity += -transform.forward * forwardFriction * rb.velocity.magnitude * drag * Time.deltaTime;


		if (Mathf.Abs(sideFriction) > 0.3f)
		{
			print("drift");
		}


		speedRatio = rb.velocity.magnitude / maxSpeed;
		engineSound.pitch = 0.5f + 1.5f*speedRatio;
	}

	public void Accelerate()
	{
		if (!isGrounded) return;
		rb.velocity += transform.forward * acceleration * Time.deltaTime;
	}

	public void Brake()
	{
		if (!isGrounded) return;
		rb.velocity += -transform.forward * acceleration * Time.deltaTime;
	}

	public void Turn(float direction)
	{
		transform.Rotate(0, direction * turnSpeed * Time.deltaTime, 0);
	}
}