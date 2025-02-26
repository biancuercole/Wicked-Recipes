using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventario : MonoBehaviour
{

    [SerializeField] private Button inventoryButton;
    [SerializeField] private GameObject inventory; 
    private bool inventoryOpen = false;

    private void closeInventory()
    {
        inventory.SetActive(false);
        inventoryOpen = false;
    }

    void openInventory()
    {
            inventoryOpen = true;
            Debug.Log("OpenInventory");
            inventory.SetActive(true);
    }

    void Update()
    {
        if(inventoryOpen)
        {
            inventoryButton.onClick.AddListener(closeInventory);
        }
        if(!inventoryOpen)
        {
            inventoryButton.onClick.AddListener(openInventory);
        }
    }

}
