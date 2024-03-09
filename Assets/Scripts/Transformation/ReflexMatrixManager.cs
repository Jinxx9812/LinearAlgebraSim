using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexMatrixManager : MonoBehaviour
{
    [SerializeField] GameObject originalVector;

    [Header("Reflex matrix")]
    [SerializeField] Vector3 row1 = new(1,0,0);
    [SerializeField] Vector3 row2 = new(0,1,0);
    [SerializeField] Vector3 row3 = new(0,0,1);

    private float[,] matrixValues = new float[3, 3];
    Matrix3x3 reflexMatrix;

    // Start is called before the first frame update
    void Start()
    {
        UpdateReflexMatrix();
    }

    private void UpdateReflexMatrix()
    {
        matrixValues = new float[3, 3]
        {
            { row1.x, row1.y, row1.z },
            { row2.x, row2.y, row2.z },
            { row3.x, row3.y, row3.z }
        };
        reflexMatrix = new Matrix3x3(matrixValues);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateReflexMatrix();
        Vector3 vectorOriginalPos = new();
        vectorOriginalPos = originalVector.transform.position;
        this.transform.position = reflexMatrix.MultiplyVector(vectorOriginalPos);
    }
}
