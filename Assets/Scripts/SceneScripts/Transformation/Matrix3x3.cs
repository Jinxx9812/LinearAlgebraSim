using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix3x3
{
    public float[,] values = new float[3, 3];

    public Matrix3x3(float[,] inputValues)
    {
        SetMatrixValues(inputValues);
    }

    public void UpdateMatrix(float[,] inputValues)
    {
        SetMatrixValues(inputValues);
    }

    private void SetMatrixValues(float[,] inputValues)
    {
        if (inputValues.GetLength(0) != 3 ||
            inputValues.GetLength(1) != 3)
        {
            Debug.LogError("Input values must be 3x3 matrix");
            return;
        }
        values = inputValues;
    }

    public Vector3 MultiplyVector(Vector3 vector)
    {
        Vector3 result = new Vector3();

        result.x = values[0,0]*vector.x + values[0,1]*vector.y + values[0,2]*vector.z;
        result.y = values[1,0]*vector.x + values[1,1]*vector.y + values[1,2]*vector.z;
        result.z = values[2,0]*vector.x + values[2,1]*vector.y + values[2,2]*vector.z;
        
        return result;
    }
}
