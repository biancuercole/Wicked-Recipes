using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeBook : MonoBehaviour
{
    public GameObject popupRecetario; // asignás el GameObject del popup

    void OnMouseDown()
    {
        if (popupRecetario != null)
        {
            popupRecetario.SetActive(true);
            GetComponent<DialogoSecuencia>().IniciarDialogo();

        }
    }

    public void CloseBook() {
        popupRecetario.SetActive(false);
    }

    public void TravelToYear()
    {
        Debug.Log("Prueba");
        GameManager.nombreEscenaGuardada = gameObject.name; // guarda el nombre del botón
        SceneManager.LoadScene("Labrynth");
    }

    
}
