using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLineRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public RotationManager rotationManager;
    public int maxLinePoints = 50;
    public float fadeSpeed = 0.5f;
    private Queue<Vector3> pointsQueue = new Queue<Vector3>();

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Vector3 currentPos = rotationManager.transform.position;
        if (pointsQueue.Count >= maxLinePoints)
        {
            pointsQueue.Dequeue();
        }
        pointsQueue.Enqueue(currentPos);

        Vector3[] pointsArray = pointsQueue.ToArray();
        lineRenderer.positionCount = pointsArray.Length;
        lineRenderer.SetPositions(pointsArray);

        FadeLine();
    }

    private void FadeLine()
    {
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            lineRenderer.colorGradient.colorKeys,
            lineRenderer.colorGradient.alphaKeys
        );

        GradientAlphaKey[] alphaKeys = gradient.alphaKeys;
        for (int i = 0; i < alphaKeys.Length; i++)
        {
            alphaKeys[i].alpha = Mathf.Max(0, alphaKeys[i].alpha - (fadeSpeed * Time.deltaTime / maxLinePoints));
        }
        gradient.SetKeys(gradient.colorKeys, alphaKeys);
        lineRenderer.colorGradient = gradient;
    }
}
