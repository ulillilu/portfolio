using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
 
public class Item
{
    public int itemID; // 고유ID
    public string itemName; // 아이템 이름
    public string itemDescription; // 아이템 설명
    public int itemCount; // 소지개수
    public Sprite itemIcon; // 아이템 아이콘
    public ItemType itemType;

    public enum ItemType
    {
        Use,
        Equip,
        Quest,
        Etc
    }

    public int atk;
    public int def;

    public Item(int _itemID, string _itemName, string _itemDes, ItemType _itemType, int _atk = 0, int _def = 0, int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("ItemIcon/" + _itemID.ToString(), typeof(Sprite)) as Sprite;

        atk = _atk;
        def = _def;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
