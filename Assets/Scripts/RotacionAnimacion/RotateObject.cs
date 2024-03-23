using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeedY = 50.0f; 
    public float rotationSpeedZ = 50.0f; 

    void Update()
    {
        
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotationSpeedZ * Time.deltaTime);
    }
}
