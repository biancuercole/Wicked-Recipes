using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTriggerDetector : MonoBehaviour
{
    private ObjectClickHandler parentHandler;

    private void Start()
    {
        parentHandler = GetComponentInParent<ObjectClickHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            parentHandler?.SetCanCollect(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            parentHandler?.SetCanCollect(false);
        }
    }
}
