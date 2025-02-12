using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravel : MonoBehaviour
{
    private bool canClick = false;
    [SerializeField] private GameObject timeMachine;

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            canClick = true;
            Debug.Log("Puede clickear");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        timeMachine.SetActive(false);
        canClick = false;
    }

    void OnMouseDown()
    {
        if (canClick)
        {
            timeMachine.SetActive(true);
            Debug.Log("Maquina del tiempo");
        }
    }
}
