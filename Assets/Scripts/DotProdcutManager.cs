using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DotProdcutManager : MonoBehaviour
{
    [SerializeField] GameObject Vector1;
    [SerializeField] GameObject Vector2;
    [SerializeField] TMP_Text v1dotv2Txt;

    // Update is called once per frame
    void Update()
    {
        Vector3 v1 = Vector1.transform.position;
        Vector3 v2 = Vector2.transform.position;
        Vector3 c = Vector3.zero;

        v1dotv2Txt.text = "v1.v2=" + DotProduct(v1, v2, c);
    }

    /// <summary>
    /// Calculate dot product
    /// </summary>
    /// <param name="p0">vector1</param>
    /// <param name="p1">vector2</param>
    /// <param name="c">reference vector</param>
    /// <returns>dot product as string</returns>
    private string DotProduct(Vector3 p0, Vector3 p1, Vector3 c)
    {
        Vector3 a = (p0 - c).normalized;
        Vector3 b = (p1 - c).normalized;

        float adotb = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        return adotb.ToString("F1");
    }
}
