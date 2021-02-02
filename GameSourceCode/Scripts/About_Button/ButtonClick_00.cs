using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick_00 : MonoBehaviour
{
    // public bool isClick = false;
    public GameObject tf;
    private InventorySlot[] slots;
    public DataBaseManager theDB;
    public GameObject usePanel;
    bool usePanelActive = true;
    private Inventory inven;
    // public Button m_Bt;
    // Start is called before the first frame update
    void Start()
    {
        // m_Bt = this.transform.GetComponent<Button>();
        slots = tf.GetComponentsInChildren<InventorySlot>(); 
        theDB = FindObjectOfType<DataBaseManager>();
        // m_Bt.onClick.AddListener(fClick);
        usePanel.SetActive(usePanelActive);
        inven = FindObjectOfType<Inventory>();
        getSlotData();
        
    }

    public void getSlotData()
    {
        if(slots[0].itemID_Text != 0)
        {
            usePanelActive = !usePanelActive;
            usePanel.SetActive(usePanelActive);
        }
        //더 많은 데이터를 불러올수있도록 inventoryslot 단계에서 데이터를 더 추가!
        theDB.selected_Item_ID = slots[0].itemID_Text;
        theDB.selected_Item_Name = slots[0].itemName_Text;
        theDB.selected_Item_Des = slots[0].itemDes_Text;
    }

    void Update()
    {
        if(inven.lenItemList < 1)
        {
            slots[0].RemoveItem();
        }
    }
}