using UnityEngine;

public class Brains : MonoBehaviour
{
    Vehicle vehicle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
    }

    void Update()
    {
        var dir = Mathf.PerlinNoise1D(Time.time) * 2 - 1;
        vehicle.Turn(dir);
        vehicle.Accelerate();
    }
}