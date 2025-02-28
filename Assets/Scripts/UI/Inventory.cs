using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private List<string> items = new List<string>();

    [SerializeField] private Button inventoryButton;
    [SerializeField] private GameObject inventory; 
    [SerializeField] private TMP_Text inventoryText; 
    private bool inventoryOpen = false;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        inventoryText.text = "Inventario:\n" + string.Join("\n", items);
    }

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
