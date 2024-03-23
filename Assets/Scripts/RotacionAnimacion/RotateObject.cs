using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeedY = 50.0f; // Speed of rotation around the Y axis
    public float rotationSpeedZ = 50.0f; // Speed of rotation around the Z axis

    // Update is called once per frame
    void Update()
    {
        // Rotate around the Y axis
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime);

        // Rotate around the Z axis
        transform.Rotate(Vector3.forward, rotationSpeedZ * Time.deltaTime);
    }
}
