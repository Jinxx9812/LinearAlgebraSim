using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager
{
    Matrix3x3 scaleMatrix = new Matrix3x3(new float[3, 3]
    {
        {1,0,0},
        {0,1,0},
        {0,0,1 }
    });

    public Vector3 ScalePoint(Vector3 scale, Vector3 p)
    {
        scaleMatrix.UpdateMatrix(new float[3, 3]
        {
            { scale.x, 0, 0 },
            { 0, scale.y, 0 },
            {0, 0, scale.z }
        });
        return scaleMatrix.MultiplyVector(p);
    }
}
