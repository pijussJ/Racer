using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 10f;
    public AudioSource engineSound;
    public Rigidbody rb;

    void Update()
    {
        print( rb.velocity.magnitude * 3.6f + " km/h");
        engineSound.pitch = 1 + rb.velocity.magnitude * 0.2f;
    }

    public void Brake()
    {

    }

    public void Gas()
    {
        rb.velocity = transform.forward * speed;
        //rb.velocity += transform.forward * speed * Time.deltaTime;
    }

    public void Turn(float amount)
    {
        transform.Rotate(0, amount * turnSpeed  * Time.deltaTime, 0);
    }
}