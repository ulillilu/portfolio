using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private InventorySlot[] slots;

    //public Text Description_Text;
    public GameObject tf; //slot의 부모 객체 여기선 Content

    private List<Item> inventoryItemList; //플레이어가 소지한 아이템 리스트

    public int selectedItem; //선택된 아이템
    private DataBaseManager theDB;
    private Equipment theEquip;
    //public GameObject prefab_floating_text;
    public GameObject target;

    public int lenItemList;

    void Start()
    {
        instance = this;
        inventoryItemList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>(); 
        theDB = FindObjectOfType<DataBaseManager>();
        theEquip = FindObjectOfType<Equipment>();
    }

    public List<Item> SaveItem()
    {
        return inventoryItemList;
    }

    public void LoadItem(List<Item> _itemList)
    {
        inventoryItemList = _itemList;
    }

    public void EquipToInventory(Item _item)
    {
        inventoryItemList.Add(_item);
    }

    public void getAnItem(int _itemID, int _count = 1)
    {
        for(int i = 0; i < theDB.itemList.Count ; i++)
        {
            if(_itemID == theDB.itemList[i].itemID)
            {
                // 플로팅 텍스트 
                //FloatingTextManager.instance.CreateFloatingText(target.transform.position, theDB.itemList[i].itemName + "" + _count + "개 획득");

                for(int j = 0; j < inventoryItemList.Count; j++)
                {
                    if(inventoryItemList[j].itemID == _itemID)
                    {
                        if(inventoryItemList[j].itemType == Item.ItemType.Use)
                        {
                            inventoryItemList[j].itemCount += _count;
                            ShowItem();
                        }
                        else
                        {
                            inventoryItemList.Add(theDB.itemList[i]);
                            ShowItem();
                        }
                        return;
                    }
                }
                inventoryItemList.Add(theDB.itemList[i]);
                inventoryItemList[inventoryItemList.Count - 1].itemCount = _count;
                ShowItem();
                return;
            }

        }
        Debug.LogError("데이터 베이스에 해당 아이디 값을 가진 아이템이 존재하지 않습니다.");

    }

    public void ShowItem()
    {
        selectedItem = theDB.selected_Item_ID;

        for(int i = 0; i < inventoryItemList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(inventoryItemList[i]);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ShowItem();
        }
        lenItemList = inventoryItemList.Count;
    }

    public void useItem()
    {
        ShowItem();
        for(int i = 0; i < inventoryItemList.Count; i++)
        {
            if(inventoryItemList[i].itemID == selectedItem)
            {
                //소모품일 경우(다수를 가질수있는 아이템의 경우)
                if(inventoryItemList[i].itemType == Item.ItemType.Use)
                {
                    theDB.effectItem(inventoryItemList[i].itemID);

                    if(inventoryItemList[i].itemCount > 1)
                    {
                            inventoryItemList[i].itemCount--;
                    }
                    else
                    {
                        slots[i].RemoveItem();
                        inventoryItemList.RemoveAt(i);
                    }
                    ShowItem();
                    break;
                }
                //소모품이 아닌 경우(하나만 가질수있는 아이템의 경우) ex장비장착
                else
                {
                    if(inventoryItemList[i].itemType == Item.ItemType.Equip)
                    {
                        theEquip.EquipItem(inventoryItemList[i]);
                        inventoryItemList.RemoveAt(i);
                        ShowItem();
                        theEquip.ShowEquip();
                        theEquip.ShowText();
                        break;
                    }
                }
            }
        }
            
    }

    public void deleteItem()
    {
        for(int i = 0; i < inventoryItemList.Count; i++)
        {
            if(inventoryItemList[i].itemID == selectedItem)
            {
                slots[i].RemoveItem();
                inventoryItemList.RemoveAt(i);
                ShowItem();
                break;
            }
        }
    }

}
