using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private Collider2D objetoEnTrigger = null;

    void Update()
    {
        ManejarMovimiento();
        ManejarInteraccion();
    }

    void ManejarMovimiento()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Raycast desde la cámara al mouse
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                // Si es el objeto en el que estamos cerca y tiene Interactable o Tag Interactuable, no moverse
                if (hit.collider == objetoEnTrigger &&
                   (hit.collider.GetComponent<Interactable>() != null || hit.collider.CompareTag("Interactuable")))
                {
                    Debug.Log("Clic sobre objeto interactuable cercano. No se mueve.");
                    return;
                }
            }

            // Si no es un objeto interactuable cercano, moverse al punto clickeado
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            targetPosition = new Vector3(mouseWorldPos.x, transform.position.y, transform.position.z);
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
                isMoving = false;
        }
    }

    void ManejarInteraccion()
    {
        if (objetoEnTrigger == null || !Keyboard.current.eKey.wasPressedThisFrame)
            return;

        Interactable interactable = objetoEnTrigger.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactable.Interactuar();
        }
        else
        {
            Debug.Log("Cerca de objeto interactuable con tag, pero sin script Interactable.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Acepta objetos con el script Interactable o con el tag "Interactuable"
        if (other.GetComponent<Interactable>() != null || other.CompareTag("Interactuable"))
        {
            objetoEnTrigger = other;
            Debug.Log("Objeto interactuable cercano detectado: " + other.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == objetoEnTrigger)
        {
            objetoEnTrigger = null;
            Debug.Log("Saliste del rango del objeto interactuable.");
        }
    }
}
