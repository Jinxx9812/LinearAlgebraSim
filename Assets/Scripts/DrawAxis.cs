using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAxis : MonoBehaviour
{
    [SerializeField] float axisLength = 1f; // Longitud de los ejes
    [SerializeField] float lineWidth = 0.05f; // Ancho de la línea
    [SerializeField] Color xColor = Color.red; // Color del eje X
    [SerializeField] Color yColor = Color.green; // Color del eje Y
    [SerializeField] Color zColor = Color.blue; // Color del eje Z

    private LineRenderer lineRenderer;

    void Start()
    {
        // Obtener el componente LineRenderer adjunto al objeto
        lineRenderer = GetComponent<LineRenderer>();

        // Establecer el ancho de la línea
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        // Establecer el número de posiciones que se dibujarán
        lineRenderer.positionCount = 6;

        // Establecer los colores de los ejes
        lineRenderer.startColor = xColor;
        lineRenderer.endColor = xColor;

        // Dibujar el eje X
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.right * axisLength);

        // Cambiar el color para dibujar el eje Y
        lineRenderer.startColor = yColor;
        lineRenderer.endColor = yColor;

        // Dibujar el eje Y
        lineRenderer.SetPosition(2, Vector3.zero);
        lineRenderer.SetPosition(3, Vector3.up * axisLength);

        // Cambiar el color para dibujar el eje Z
        lineRenderer.startColor = zColor;
        lineRenderer.endColor = zColor;

        // Dibujar el eje Z
        lineRenderer.SetPosition(4, Vector3.zero);
        lineRenderer.SetPosition(5, Vector3.forward * axisLength);
    }
}
