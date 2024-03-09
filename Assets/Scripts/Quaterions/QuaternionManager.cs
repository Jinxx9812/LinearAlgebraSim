using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionManager
{
    public Vector3 RotatePoint(float angle, Vector3 axis, Vector3 p)
    {
        float radianAngle = angle * Mathf.PI / 180;
        Vector3 rotateAxis = axis;

        return MyQuaternion.Rotate(p, rotateAxis, radianAngle);
    }
}

public struct MyQuaternion
{
    private float x;
    private float y; 
    private float z;
    private float w;

    public MyQuaternion(float x, float y, float z, float w)
    {
        this.x = x; 
        this.y = y; 
        this.z = z; 
        this.w = w;
    }

    private static MyQuaternion RotationQuaternion(float angle, Vector3 axis)
    {
        float sin = Mathf.Sin(angle/2f);
        float cos = Mathf.Cos(angle/2f);
        Vector3 v = Vector3.Normalize(axis) * sin;

        return new MyQuaternion(v.x, v.y, v.z, cos);
    }

    private static MyQuaternion ConjugateQuaternion(MyQuaternion q)
    {
        float s = q.w;
        Vector3 v = new Vector3(-q.x, -q.y, -q.z);

        return new MyQuaternion(v.x, v.y, v.z, s);
    }

    private static MyQuaternion QuaternionProduct (MyQuaternion q1, MyQuaternion q2)
    {
        float s1 = q1.w;
        float s2 = q2.w;

        Vector3 v1 = new Vector3(q1.x, q1.y, q1.z);
        Vector3 v2 = new Vector3(q2.x, q2.y, q2.z);

        float s = s1 * s2 - Vector3.Dot(v1, v2);
        Vector3 v = s1*v2 + s2*v1 + Vector3.Cross(v1, v2);

        return new MyQuaternion(v.x, v.y, v.z, s);
    }

    public static Vector3 Rotate(Vector3 point, Vector3 axis, float angle)
    {
        MyQuaternion q = RotationQuaternion(angle, axis);
        MyQuaternion _q = ConjugateQuaternion(q);
        MyQuaternion p = new MyQuaternion(point.x,point.y, point.z, 0f);

        MyQuaternion rotatedPoint = QuaternionProduct(q, p);
        rotatedPoint = QuaternionProduct(rotatedPoint, _q);

        return new Vector3(rotatedPoint.x, rotatedPoint.y, rotatedPoint.z);
    }
}
