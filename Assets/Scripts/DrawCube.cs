using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCube : MonoBehaviour
{
    QuaternionManager myQuaternion = new();
    [Header("Quaterion component")]
    [SerializeField]
    [Range(0, 360)]
    float angle = 0;
    [SerializeField] Vector3 axis = new(0, 1, 0);

    [Header("Scale component")]
    [SerializeField] Vector3 scale = Vector3.one;
    ScaleManager myScale = new();

    [Header("Position component")]
    [SerializeField] Vector3 position = Vector3.zero;
    PositionManager myPos = new();

    private LineRenderer lineRenderer;

    private Vector3[] vertices = new Vector3[]
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

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        RestartCubePosition();
        RotationCube();
        ResizeCube();
        SetPosition();
        DrawCube3D();
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
        // vertex on linerenderer
        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);

        // define lines that conect vertex
        int[] cubeIndex = new int[]
        {
            0,1,1,2,2,3,3,0, // bottom cube face
            4,5,5,6,6,7,7,4, // upper cube face
            0,4,1,5,2,6,3,7
        };

        // draw lines
        lineRenderer.positionCount = cubeIndex.Length;
        for(int i = 0; i < cubeIndex.Length; i++)
        {
            lineRenderer.SetPosition(i, vertices[cubeIndex[i]]);
        }
    }

    private void RotationCube()
    {
        for (int i = 0;i < vertices.Length;i++)
        {
            vertices[i] = myQuaternion.RotatePoint(angle, axis, vertices[i]);
        }
    }

    private void ResizeCube()
    {
        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myScale.ScalePoint(scale, vertices[i]);
        }
    }

    private void SetPosition()
    {
        for(int i=0; i < vertices.Length; i++)
        {
            vertices[i] = myPos.SetPointPos(position, vertices[i]);
        }
    }
}
