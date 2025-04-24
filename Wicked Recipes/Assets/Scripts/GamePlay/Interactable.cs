using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public GameObject lupaPrefab;
    private GameObject lupaInstanciada;
    [SerializeField] private GameObject curtainSprite;
    [SerializeField] private GameObject dough; // ✅ Referencia al objeto de la cortina

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

    void OnMouseDown()
{
    if (jugadorCerca)
    {
        Interactuar();

        // CAMBIO: Usamos escritura tipo máquina de escribir
        DialogoUI.Instance.EscribirTexto(mensajeAlInteractuar, 0.03f);
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
            // CAMBIO
            DialogoUI.Instance.EscribirTexto("Está cerrado... necesito una llave.", 0.03f);
        }
    }
    else if (CompareTag("Caja"))
    {
        if (inventario != null && inventario.TieneTodosLosIngredientes())
        {
            Debug.Log("Minijuego comenzado");
            FindFirstObjectByType<BakingMinigame>().IniciarMinijuego();
        }
        else
        {
            // CAMBIO
            DialogoUI.Instance.EscribirTexto("Te falta recolectar ingredientes.", 0.03f);
        }
    }
    else if (CompareTag("Cortina"))
    {
        // CAMBIO
        DialogoUI.Instance.EscribirTexto("Abriste la cortina. ¡Parece que hay algo!", 0.03f);

        dough.SetActive(true);
        curtainSprite.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
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
