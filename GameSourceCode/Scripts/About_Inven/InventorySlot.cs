using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public string itemName_Text;
    public string itemDes_Text;
    public Text itemCount_Text;
    public int itemID_Text;
    public GameObject selected_Item;

    public Sprite nullImage;

    public void Additem(Item _item)
    {
        itemID_Text = _item.itemID;
        itemName_Text = _item.itemName;
        itemDes_Text = _item.itemDescription;
        icon.sprite = _item.itemIcon;
        if(Item.ItemType.Use == _item.itemType)
        {
            if(_item.itemCount > 0)
            {
                itemCount_Text.text = "x " + _item.itemCount.ToString();
            }
            else
            {
                itemCount_Text.text = "";
            }

        }
    }

    public void RemoveItem()
    {
        //itemName_Text.text = "";
        itemCount_Text.text = "";
        icon.sprite = nullImage;
    }
}
