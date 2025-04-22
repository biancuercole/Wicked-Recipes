using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public GameObject lupaPrefab;
    private GameObject lupaInstanciada;

    private bool jugadorCerca = false; // ✅ Para saber si el jugador está cerca

    [TextArea]
    public string mensajeAlInteractuar; // ✅ Para mostrar texto al interactuar

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            MostrarLupa();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            OcultarLupa();
        }
    }

    void OnMouseDown() // ✅ Detectar clic sobre el objeto
    {
        if (jugadorCerca)
        {
            Interactuar();
            DialogoUI.Instance.MostrarDialogo(mensajeAlInteractuar); // ✅ Mostrar mensaje del personaje
        }
    }

    public void Interactuar()
{
    PlayerInventory inventario = PlayerInventory.Instance;

    if (CompareTag("Cajon"))
    {
        if (inventario != null && inventario.tieneLlave)
        {
            Debug.Log("Abriendo cajón...");
            SceneManager.LoadScene("Drawer");
        }
        else
        {
            DialogoUI.Instance.MostrarDialogo("Está cerrado... necesito una llave.");
        }
    }
    else if (CompareTag("Caja"))
    {
        if (inventario != null && inventario.TieneTodosLosIngredientes())
        {
            Debug.Log("Minijuego comenzado");
            FindFirstObjectByType<CutMinigame>().IniciarMinijuego();
        }
        else
        {
            Debug.Log("Te falta recolectar ingredientes.");
        }
    }
    else
    {
        Debug.Log("Objeto interactuado sin acción definida.");
    }
}


    void MostrarLupa()
    {
        if (lupaPrefab != null && lupaInstanciada == null)
        {
            lupaInstanciada = Instantiate(lupaPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            lupaInstanciada.transform.SetParent(transform);
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
