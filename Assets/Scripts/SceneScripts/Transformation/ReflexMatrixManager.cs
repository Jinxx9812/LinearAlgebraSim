using UnityEngine;
using UnityEngine.UI;

public class ReflexMatrixManager : MonoBehaviour
{
    [SerializeField] GameObject originalVector;
    [SerializeField] GameObject parentObject; // Objeto padre que quieres activar o desactivar

    [Header("Toggles")]
    public Toggle toggleX;
    public Toggle toggleY;
    public Toggle toggleZ;

    private Matrix3x3 reflexMatrix;

    // Start is called before the first frame update
    void Start()
    {
        // Añadir listeners a los toggles
        toggleX.onValueChanged.AddListener(delegate { UpdateReflexMatrix(); });
        toggleY.onValueChanged.AddListener(delegate { UpdateReflexMatrix(); });
        toggleZ.onValueChanged.AddListener(delegate { UpdateReflexMatrix(); });

        UpdateReflexMatrix();
    }

    private void UpdateReflexMatrix()
    {
        // Configurar la matriz de reflexión basada en el estado de los toggles
        reflexMatrix = new Matrix3x3(new float[3, 3]
        {
            { toggleX.isOn ? -1 : 1, 0, 0 },
            { 0, toggleY.isOn ? -1 : 1, 0 },
            { 0, 0, toggleZ.isOn ? -1 : 1 }
        });

        // Comprobar si algún toggle está activo y activar/desactivar el objeto padre
        parentObject.SetActive(toggleX.isOn || toggleY.isOn || toggleZ.isOn);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorOriginalPos = originalVector.transform.position;
        this.transform.position = reflexMatrix.MultiplyVector(vectorOriginalPos);
    }
}
