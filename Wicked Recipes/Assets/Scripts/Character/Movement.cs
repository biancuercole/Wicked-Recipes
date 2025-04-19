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
            interactable.Interactuar();
        else
            Debug.Log("El objeto no tiene el componente Interactable.");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Interactable>() != null)
            objetoEnTrigger = other;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == objetoEnTrigger)
            objetoEnTrigger = null;
    }
}
