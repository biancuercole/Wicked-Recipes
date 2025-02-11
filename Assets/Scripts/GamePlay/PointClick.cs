using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform movePoint;
    [SerializeField] private Vector3 worldPosition;

    void Start()
    {
        // Asegurar que el punto de movimiento inicie en la posición del personaje
        movePoint.position = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Solo cambiar la posición en X, manteniendo la altura original
            worldPosition.y = transform.position.y;
        }

        // Solo cambiar la posición en X del movePoint
        movePoint.position = new Vector3(worldPosition.x, transform.position.y, transform.position.z);

        // Mover solo en el eje X
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }
}
