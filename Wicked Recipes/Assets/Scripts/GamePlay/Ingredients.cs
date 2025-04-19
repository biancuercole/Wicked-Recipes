using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public string nombreIngrediente; // "Pan" o "Tomate"
    private bool jugadorCerca = false;
    private PlayerInventory inventarioJugador;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            if (inventarioJugador != null)
            {
                inventarioJugador.RecolectarIngrediente(nombreIngrediente);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            inventarioJugador = other.GetComponent<PlayerInventory>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            inventarioJugador = null;
        }
    }
}
