using UnityEngine;
using UnityEngine.UI;

public class ReflexMatrixManager : MonoBehaviour
{
    [SerializeField] GameObject originalVector;
    [SerializeField] GameObject parentObject; 

    [Header("Toggles")]
    public Toggle toggleX;
    public Toggle toggleY;
    public Toggle toggleZ;

    private Matrix3x3 reflexMatrix;

 
    void Start()
    {
        toggleX.onValueChanged.AddListener(delegate { UpdateReflexMatrix(); });
        toggleY.onValueChanged.AddListener(delegate { UpdateReflexMatrix(); });
        toggleZ.onValueChanged.AddListener(delegate { UpdateReflexMatrix(); });

        UpdateReflexMatrix();
    }

    private void UpdateReflexMatrix()
    {
        reflexMatrix = new Matrix3x3(new float[3, 3]
        {
            { toggleX.isOn ? -1 : 1, 0, 0 },
            { 0, toggleY.isOn ? -1 : 1, 0 },
            { 0, 0, toggleZ.isOn ? -1 : 1 }
        });

        parentObject.SetActive(toggleX.isOn || toggleY.isOn || toggleZ.isOn);
    }


    void Update()
    {
        Vector3 vectorOriginalPos = originalVector.transform.position;
        this.transform.position = reflexMatrix.MultiplyVector(vectorOriginalPos);
    }
}
