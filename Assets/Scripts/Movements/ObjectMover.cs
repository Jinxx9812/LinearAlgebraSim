using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private GameObject currentSelectedObject;
    private Camera mainCamera;
    private bool isDragging = false;
    public float moveSensitivity = 0.1f; //Velocity

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
            isDragging = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            MoveSelectedObject();
        }
    }

    private void MoveSelectedObject()
    {
        //AXIS YZ.
        float mouseY = Input.GetAxis("Mouse Y") * moveSensitivity;
        float mouseZ = Input.GetAxis("Mouse X") * moveSensitivity; 

        Vector3 newPosition = currentSelectedObject.transform.position;
        newPosition.y += mouseY;
        newPosition.z += mouseZ;

        currentSelectedObject.transform.position = newPosition;
    }
}
