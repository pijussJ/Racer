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
         vehicle.Gas();
         vehicle.Turn(Random.Range(-1f,1f));
    }
}