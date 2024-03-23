using UnityEngine;
using TMPro;

public class DotProductManager : MonoBehaviour
{
    [SerializeField] GameObject Vector1;
    [SerializeField] GameObject Vector2;
    [SerializeField] TMP_Text v1dotv2Txt;
    [SerializeField] LineRenderer slerpLineRenderer;
    public int curveResolution = 20; 

    void Update()
    {
        Vector3 v1 = Vector1.transform.position;
        Vector3 v2 = Vector2.transform.position;
        Vector3 c = Vector3.zero;

        v1dotv2Txt.text = "v1.v2=" + DotProduct(v1, v2, c);
        DrawSlerpCurve(v1, v2, c);
    }

    private string DotProduct(Vector3 p0, Vector3 p1, Vector3 c)
    {
        Vector3 a = (p0 - c).normalized;
        Vector3 b = (p1 - c).normalized;

        float adotb = Vector3.Dot(a, b);
        float angle = Mathf.Acos(adotb) * Mathf.Rad2Deg;

        return adotb.ToString("F1") + ", Angle: " + angle.ToString("F1") + "°";
    }


    private void DrawSlerpCurve(Vector3 v1, Vector3 v2, Vector3 c)
    {
        
        Vector3 normV1 = (v1 - c).normalized / 3;
        Vector3 normV2 = (v2 - c).normalized / 3;

        slerpLineRenderer.positionCount = curveResolution;
        for (int i = 0; i < curveResolution; i++)
        {
            float t = i / (float)(curveResolution - 1);
            Vector3 curvePoint = Vector3.Slerp(normV1, normV2, t);

            slerpLineRenderer.SetPosition(i, curvePoint * 3);
        }
    }

}
