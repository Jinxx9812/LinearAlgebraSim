using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private GameObject currentSelectedObject;
    private Camera mainCamera;
    private bool isDragging = false;
    public float moveSensitivity = 0.1f; // Agrega una sensibilidad de movimiento para controlar la velocidad.

    void OnEnable()
    {
        ObjectSelector.OnObjectSelected += HandleObjectSelected;
        mainCamera = Camera.main;
    }

    void OnDisable()
    {
        ObjectSelector.OnObjectSelected -= HandleObjectSelected;
    }

    private void HandleObjectSelected(GameObject selectedObj)
    {
        currentSelectedObject = selectedObj;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentSelectedObject != null)
        {
            // Comienza el arrastre si se seleccionó un objeto.
            isDragging = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            // Finaliza el arrastre cuando se suelta el botón del mouse.
            isDragging = false;
        }

        if (isDragging)
        {
            MoveSelectedObject();
        }
    }

    private void MoveSelectedObject()
    {
        // Obtiene el desplazamiento del mouse en los ejes Y y Z.
        float mouseY = Input.GetAxis("Mouse Y") * moveSensitivity;
        float mouseZ = Input.GetAxis("Mouse X") * moveSensitivity; // Usamos Mouse X para el eje Z para una experiencia más intuitiva.

        // Calcular la nueva posición basada en el desplazamiento del mouse.
        Vector3 newPosition = currentSelectedObject.transform.position;
        newPosition.y += mouseY;
        newPosition.z += mouseZ;

        // Aplicar la nueva posición al objeto seleccionado.
        currentSelectedObject.transform.position = newPosition;
    }
}
