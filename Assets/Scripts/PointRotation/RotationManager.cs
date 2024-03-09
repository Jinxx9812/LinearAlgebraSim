using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationManager : MonoBehaviour
{
    [SerializeField]
    [Range(0, 360)]
    float angle = 0.0f;
    Matrix2x2 RotationMatrix = new Matrix2x2(new float[2, 2]{
        {1,0},
        {0,1}
    });

    [SerializeField] Slider angleSlider; 

    Vector2 initPos = new Vector2();

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        // reinicio la pos inicial
        this.transform.position = initPos;

        // pos de mi punto
        Vector2 p = transform.position;

        // actualizo el angle desde el UI
        angle = angleSlider.value;

        // calculos para la matriz
        float cos = Mathf.Cos(angle*Mathf.PI/180f);
        float sin = Mathf.Sin(angle*Mathf.PI/180f);

        // actualizo la matriz
        RotationMatrix.UpdateMatrix(new float[2, 2]
        {
            {cos, -sin},
            {sin, cos}
        });

        // calculo la nueva ubicación de mi punto
        this.transform.position = RotationMatrix.MultiplyVector(p);
    }
}
