using UnityEngine;
using UnityEngine.UI;

public class RotationManager : MonoBehaviour
{
    [SerializeField] Transform rotationReference;
    [SerializeField] float angle = 0.0f;
    [SerializeField] Slider angleSlider;

    private Vector2 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        angle = angleSlider.value;
        RotateAroundPoint();
    }

    void RotateAroundPoint()
    {
        float cos = Mathf.Cos(angle * Mathf.PI / 180f);
        float sin = Mathf.Sin(angle * Mathf.PI / 180f);
        Vector2 translatedPos = initPos - (Vector2)rotationReference.position;
        Vector2 rotatedPos = new Vector2(
            translatedPos.x * cos - translatedPos.y * sin,
            translatedPos.x * sin + translatedPos.y * cos
        );
        transform.position = rotatedPos + (Vector2)rotationReference.position;
    }
}
