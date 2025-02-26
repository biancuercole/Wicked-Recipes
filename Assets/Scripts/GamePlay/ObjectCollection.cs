using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    private bool canCollect = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canCollect) // Detecta clic izquierdo
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D clickedObject = Physics2D.OverlapPoint(mousePos);

            if (clickedObject != null && clickedObject.transform.IsChildOf(transform))
            {
                Debug.Log("Objeto tocado: " + clickedObject.name);
                clickedObject.gameObject.SetActive(false);
            }
        }
    }

    public void SetCanCollect(bool value)
    {
        canCollect = value;
        Debug.Log(value ? "Puede clickear" : "Ya no puede clickear");
    }
}
