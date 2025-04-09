using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public string mensajeLog = "Interactuaste con un objeto.";
    public bool cambiaEscena = false;
    public string nombreEscena = "Cajon";
    public GameObject lupaPrefab;

    private GameObject lupaInstanciada;
    private bool enRango = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enRango = true;
            MostrarLupa();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enRango = false;
            OcultarLupa();
        }
    }

    void Update()
    {
        if (enRango && Input.GetKeyDown(KeyCode.E))
        {
            if (cambiaEscena)
            {
                SceneManager.LoadScene(nombreEscena);
            }
            else
            {
                Debug.Log(mensajeLog);
            }
        }
    }

    void MostrarLupa()
    {
        if (lupaPrefab != null && lupaInstanciada == null)
        {
            lupaInstanciada = Instantiate(lupaPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            lupaInstanciada.transform.SetParent(transform); // para que se mueva con el objeto si hace falta
        }
    }

    void OcultarLupa()
    {
        if (lupaInstanciada != null)
        {
            Destroy(lupaInstanciada);
            lupaInstanciada = null;
        }
    }
}
