using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProductManager : MonoBehaviour
{
    [SerializeField] GameObject vector1;
    [SerializeField] GameObject vector2;
    [SerializeField] GameObject v1Crossv2;

    // Update is called once per frame
    void Update()
    {
        Vector3 v1 = vector1.transform.position;
        Vector3 v2 = vector2.transform.position;

        v1Crossv2.transform.position = CrossProduct(v1, v2);
        //v1Crossv2.transform.position = Vector3.Cross(v1, v2);
    }

    private Vector3 CrossProduct(Vector3 p, Vector3 q)
    {
        float x = p.z * q.z - p.z * q.y;
        float y = p.z * q.x - p.x * q.z;
        float z = p.x * q.y - p.y * q.x;

        return new Vector3(x, y, z);
    }
}
