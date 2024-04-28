using UnityEngine;

public class Car : MonoBehaviour
{
	public float moveForce = 10f;
	public float reverseForce = 1;
	public float turnSpeed = 100f;
	public Rigidbody ballRB;
	public Transform visuals;

	void Update()
	{
		var input = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		var force = input.y > 0 ? moveForce : reverseForce;
		ballRB.AddForce(transform.forward * input.y * force);

		transform.Rotate(0,input.x * turnSpeed * Time.deltaTime * input.y,0);

		// visual
		var isGrounded = Physics.Raycast( transform.position, Vector3.down, out var hit,0.6f);
		var angle = Vector3.SignedAngle(Vector3.up, hit.normal, Vector3.right);

		visuals.localEulerAngles = new Vector3(angle, 0, 0);
	}
}