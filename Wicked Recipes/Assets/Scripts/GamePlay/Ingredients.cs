using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public string nombreIngrediente; // "Pan" o "Tomate"
    private bool jugadorCerca = false;

    void OnMouseDown()
    {
        Debug.Log("click00");
        if (jugadorCerca && PlayerInventory.Instance != null)
        {
            Debug.Log("click01");
            PlayerInventory.Instance.RecolectarIngrediente(nombreIngrediente);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}
