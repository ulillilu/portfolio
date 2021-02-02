using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject usePanel;
    bool activeInventory = false;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(activeInventory);
        usePanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            usePanel.SetActive(false);
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
        
    }
}
