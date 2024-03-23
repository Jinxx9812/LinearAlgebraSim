using UnityEngine;

public class AxisLineProjection : MonoBehaviour
{
    public LineRenderer lineRendererX;
    public LineRenderer lineRendererY;
    public LineRenderer lineRendererZ;
    public float lineLength = 5.0f; // Longitud 

    void Start()
    {
        SetLinePositions(lineRendererX, Vector3.right);
        SetLinePositions(lineRendererY, Vector3.up);
        SetLinePositions(lineRendererZ, Vector3.forward);
    }

    void SetLinePositions(LineRenderer lineRenderer, Vector3 direction)
    {
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + direction * lineLength);
        }
    }
}
