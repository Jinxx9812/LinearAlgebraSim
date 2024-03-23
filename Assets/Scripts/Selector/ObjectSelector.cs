using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public Material selectedMaterial;
    private Material defaultMaterial;
    public static GameObject selectedObject; // Hacerlo público y estático para acceder desde otros scripts.

    public delegate void ObjectSelected(GameObject obj);
    public static event ObjectSelected OnObjectSelected; // Evento para notificar cuando un objeto es seleccionado.

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

        OnObjectSelected?.Invoke(obj); // Invocar el evento.
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
