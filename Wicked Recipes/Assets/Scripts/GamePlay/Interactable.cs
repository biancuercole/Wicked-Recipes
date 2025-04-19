using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public GameObject lupaPrefab;
    private GameObject lupaInstanciada;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            MostrarLupa();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            OcultarLupa();
    }

    public void Interactuar()
    {
        if (CompareTag("Cajon"))
        {
            Debug.Log("Cambiando a escena: Drawer");
            SceneManager.LoadScene("Drawer");
        }
        else if (CompareTag("Caja"))
        {
            PlayerInventory inventario = GameObject.FindWithTag("Player")?.GetComponent<PlayerInventory>();

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
