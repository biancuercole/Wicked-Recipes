using UnityEngine;

public class Cabinet : MonoBehaviour
{
    private bool jugadorCerca = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject openSprite;
    [SerializeField] private GameObject worms;

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

    void OnMouseDown()
    {
        if (jugadorCerca)
        {
            if (PlayerInventory.Instance.llaveEspecialObtenida)
            {
                AbrirGabinete();
            }
            else
            {
                DialogoUI.Instance.EscribirTexto("Está trabado... parece que necesita una llave especial.", 0.03f);
            }
        }
    }

    void AbrirGabinete()
    {
        DialogoUI.Instance.EscribirTexto("Acá están mis gusanos! Ellos aman la oscuridad", 0.03f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        openSprite.SetActive(true); // Cambia el sprite del gabinete a uno abierto
        worms.SetActive(true); // Activa el objeto de los gusanos

        // Cambia el sprite del gabinete a uno abierto
        // Acá podés:
        // - Reproducir una animación
        // - Activar un objeto
        // - Cambiar de escena
        // - Etc.
    }
}
