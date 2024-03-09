using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager
{
    Matrix4x4Class positionMatrix = new Matrix4x4Class(new float[4, 4]
    {
        {1,0,0,0},
        {0,1,0,0},
        {0,0,1,0},
        {0,0,0,1},
    });

    public Vector3 SetPointPos(Vector3 newPos, Vector3 _p)
    {
        positionMatrix.UpdateMatrix(new float[4, 4]
        {
            { 1,0,0,newPos.x },
            {0,1,0,newPos.y },
            { 0,0,1,newPos.z},
            { 0,0,0,1 }
        });
        Vector4 p = new(_p.x, _p.y, _p.z, 1);

        Vector4 newP = positionMatrix.MultiplyVector(p);

        return new Vector3(newP.x, newP.y, newP.z);
    }
}
