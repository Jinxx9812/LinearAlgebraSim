using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public Material selectedMaterial;
    private Material defaultMaterial;
    public static GameObject selectedObject; 

    public delegate void ObjectSelected(GameObject obj);
    public static event ObjectSelected OnObjectSelected;

    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            selectedObject.GetComponent<Renderer>().material = defaultMaterial;
        }

        selectedObject = obj;
        defaultMaterial = obj.GetComponent<Renderer>().material;
        obj.GetComponent<Renderer>().material = selectedMaterial;

        Debug.Log("Objeto seleccionado: " + obj.name);

        OnObjectSelected?.Invoke(obj); 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Selectable"))
                {
                    SelectObject(hit.transform.gameObject);
                }
            }
        }
    }
}
