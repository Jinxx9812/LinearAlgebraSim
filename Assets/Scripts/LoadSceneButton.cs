using UnityEngine;
using UnityEngine.SceneManagement; // Necesitas esta línea para trabajar con el sistema de manejo de escenas

public class LoadSceneButton : MonoBehaviour
{
    // Método público para cargar la escena
    public void LoadScene()
    {
        SceneManager.LoadScene(0); // Carga la escena con índice 0
    }
}
