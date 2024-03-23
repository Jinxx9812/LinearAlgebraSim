using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCube : MonoBehaviour
{
    [Header("Axis Toggles")]
    public Toggle toggleX;
    public Toggle toggleY;
    public Toggle toggleZ;

    [Header("Angle Slider")]
    public Slider angleSlider;

    [Header("Movement Sliders")]
    public Slider moveSliderX;
    public Slider moveSliderY;
    public Slider moveSliderZ;
    QuaternionManager myQuaternion = new();
    [SerializeField] Vector3 axis = Vector3.zero;

    [Header("Scale component")]
    [SerializeField] Vector3 scale = Vector3.one;
    ScaleManager myScale = new();

    [Header("Scale Sliders")]
    public Slider scaleSliderX;
    public Slider scaleSliderY;
    public Slider scaleSliderZ;

    [Header("Position component")]
    [SerializeField] Vector3 position = Vector3.zero;
    PositionManager myPos = new();

    private LineRenderer lineRenderer;

    private Vector3[] vertices = new Vector3[]
    {        
        new Vector3(-0.5f, -0.5f, -0.5f),
        new Vector3(0.5f, -0.5f, -0.5f),
        new Vector3(0.5f, -0.5f, 0.5f),
        new Vector3(-0.5f, -0.5f, 0.5f),
        new Vector3(-0.5f, 0.5f, -0.5f),
        new Vector3(0.5f, 0.5f, -0.5f),
        new Vector3(0.5f, 0.5f, 0.5f),
        new Vector3(-0.5f, 0.5f, 0.5f)
    };

        private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Inicializar los sliders de movimiento y escala
        moveSliderX.gameObject.SetActive(toggleX.isOn);
        moveSliderY.gameObject.SetActive(toggleY.isOn);
        moveSliderZ.gameObject.SetActive(toggleZ.isOn);

        scaleSliderX.gameObject.SetActive(toggleX.isOn);
        scaleSliderY.gameObject.SetActive(toggleY.isOn);
        scaleSliderZ.gameObject.SetActive(toggleZ.isOn);

        // Asegúrate de que los sliders de escala tengan un valor por defecto que represente la escala inicial.
        scaleSliderX.value = scale.x;
        scaleSliderY.value = scale.y;
        scaleSliderZ.value = scale.z;
        
        // Suscribirse a los eventos de los sliders
        scaleSliderX.onValueChanged.AddListener(newValue => UpdateScaleX(newValue));
        scaleSliderY.onValueChanged.AddListener(newValue => UpdateScaleY(newValue));
        scaleSliderZ.onValueChanged.AddListener(newValue => UpdateScaleZ(newValue));
    }


    private void Update()
    {
        UpdateAxisFromToggles();
        RestartCubePosition();
        RotationCube();
        ResizeCube();
        SetPosition();
        DrawCube3D();
        
    }

    private void UpdateAxisFromToggles()
    {
        // Controlar la visibilidad de los sliders de movimiento y de escala basado en los toggles.
        moveSliderX.gameObject.SetActive(toggleX.isOn);
        moveSliderY.gameObject.SetActive(toggleY.isOn);
        moveSliderZ.gameObject.SetActive(toggleZ.isOn);

        scaleSliderX.gameObject.SetActive(toggleX.isOn);
        scaleSliderY.gameObject.SetActive(toggleY.isOn);
        scaleSliderZ.gameObject.SetActive(toggleZ.isOn);

        // Activar el slider de ángulo si alguno de los toggles está activado
        angleSlider.gameObject.SetActive(toggleX.isOn || toggleY.isOn || toggleZ.isOn);

        // Actualiza los ejes basándose en los estados de los toggles
        axis.x = toggleX.isOn ? 1 : 0;
        axis.y = toggleY.isOn ? 1 : 0;
        axis.z = toggleZ.isOn ? 1 : 0;
    }


    private void RotationCube()
    {
        float angle = angleSlider.value; // Usa el valor del Slider para el ángulo.
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myQuaternion.RotatePoint(angle, axis, vertices[i]);
        }
    }

    private void RestartCubePosition()
    {
        vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
            new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
            new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
            new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
            new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
            new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
            new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
            new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7
        };
    }

    private void DrawCube3D()
    {
        // Definición de líneas que conectan los vértices.
        int[] cubeIndex = new int[]
        {
            0,1,1,2,2,3,3,0, // bottom cube face
            4,5,5,6,6,7,7,4, // upper cube face
            0,4,1,5,2,6,3,7  // sides
        };
lineRenderer.positionCount = cubeIndex.Length;
        for (int i = 0; i < cubeIndex.Length; i++)
        {
            lineRenderer.SetPosition(i, vertices[cubeIndex[i]]);
        }
    }

    

    private void ResizeCube()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myScale.ScalePoint(scale, vertices[i]);
        }
    }

    private void SetPosition()
    {
        // Usar el valor de los sliders de movimiento para establecer la posición, si el toggle correspondiente está activado.
        if (toggleX.isOn)
        {
            position.x = moveSliderX.value;
        }
        if (toggleY.isOn)
        {
            position.y = moveSliderY.value;
        }
        if (toggleZ.isOn)
        {
            position.z = moveSliderZ.value;
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myPos.SetPointPos(position, vertices[i]);
        }
    }


    private void UpdateScaleX(float newValue)
    {
        scale.x = newValue;
        UpdateScale();
    }

    private void UpdateScaleY(float newValue)
    {
        scale.y = newValue;
        UpdateScale();
    }

    private void UpdateScaleZ(float newValue)
    {
        scale.z = newValue;
        UpdateScale();
    }


    private void UpdateScale()
    {
        // Asumiendo que 'myScale' es una clase que maneja la escala y 'ScalePoint' es el método que la actualiza.
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myScale.ScalePoint(scale, vertices[i]);
        }

        // Actualizar las posiciones de los vértices en el LineRenderer si es necesario.
        DrawCube3D();
    }
}