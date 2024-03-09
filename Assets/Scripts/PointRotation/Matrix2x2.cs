using UnityEngine;

public class Matrix2x2
{
    public float[,] values = new float[2, 2];

    public Matrix2x2(float[,] inputValues)
    {
        SetMatrixValues(inputValues);
    }

    public void UpdateMatrix(float[,] inputValues)
    {
        SetMatrixValues(inputValues);
    }

    private void SetMatrixValues(float[,] inputValues)
    {
        if (inputValues.GetLength(0) != 2 ||
            inputValues.GetLength(1) != 2)
        {
            Debug.LogError("Input values must be a 2x2 matrix");
            return;
        }
        values = inputValues;
    }

    public Vector2 MultiplyVector(Vector2 vector)
    {
        Vector2 result = new Vector2();

        result.x = values[0, 0] * vector.x + values[0, 1] * vector.y;
        result.y = values[1, 0] * vector.x + values[1, 1] * vector.y;

        return result;
    }
}

