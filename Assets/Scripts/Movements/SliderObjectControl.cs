using UnityEngine;
using UnityEngine.UI;

public class SliderObjectControl : MonoBehaviour
{
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    private GameObject currentObject;

    void OnEnable()
    {
        ObjectSelector.OnObjectSelected += UpdateCurrentObject;
    }

    void OnDisable()
    {
        ObjectSelector.OnObjectSelected -= UpdateCurrentObject;
    }

    void UpdateCurrentObject(GameObject selected)
    {
        currentObject = selected;
        UpdateSliders();
    }

    void Start()
    {
        sliderX.onValueChanged.AddListener((value) => UpdateObjectPosition('x', value));
        sliderY.onValueChanged.AddListener((value) => UpdateObjectPosition('y', value));
        sliderZ.onValueChanged.AddListener((value) => UpdateObjectPosition('z', value));
    }

    void UpdateSliders()
    {
        if (currentObject != null)
        {
            sliderX.value = currentObject.transform.position.x;
            sliderY.value = currentObject.transform.position.y;
            sliderZ.value = currentObject.transform.position.z;
        }
    }

    void UpdateObjectPosition(char axis, float value)
    {
        if (currentObject == null) return;

        Vector3 newPosition = currentObject.transform.position;

        switch (axis)
        {
            case 'x':
                newPosition.x = value;
                break;
            case 'y':
                newPosition.y = value;
                break;
            case 'z':
                newPosition.z = value;
                break;
        }

        currentObject.transform.position = newPosition;
    }
}
