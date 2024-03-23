using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVector : MonoBehaviour
{
    private Vector3 p0 = Vector3.zero;
    private Vector3 p1 = new();
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        p1 = transform.position;
        lineRenderer.SetPositions(new Vector3[] {p0, p1});
    }
}
