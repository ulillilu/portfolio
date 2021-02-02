using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    private Player_Stat thePlayerStat;
    private Inventory theInven;

    private const int WEAPON = 0, RING = 1, AMULT = 2;
    private const int HP = 0, ATK = 1, DEF = 2, LV = 3;

    public int added_atk, added_def;

    public GameObject go; //장비창 활성화
    public Text[] text; // 스탯
    public Image[] img_slots; // 장비 슬롯 아이콘

    public Item[] equipItemList; // 장착된 장비 리스트.

    public int selectedSlot; // 선택된 장비 슬롯.

    public bool activated = false;

    // Start is called before the first frame update
    void Start()
    {   
        thePlayerStat = FindObjectOfType<Player_Stat>();
        theInven = FindObjectOfType<Inventory>();
    }

    public void SelectedSlot()
    {
        string selectedItem = theInven.selectedItem.ToString();
        selectedItem = selectedItem.Substring(0, 3);
        switch (selectedItem)
        {
            case "200": // 무기
                selectedSlot = 0;
                break;
            case "201": // 반지
                selectedSlot = 1;
                break;
            case "202": // 아뮬렛
                selectedSlot = 2;
                break;
        }
    }

    // 아이템이 장착되어 있으면 벗고 선택한것을 입는다.
    public void EquipItemCheck(int _count, Item _item)
    {
        if(equipItemList[_count].itemID == 0)
        {
            equipItemList[_count] = _item;
        }
        else
        {
            //벗을때 능력치 감소하는거 구현해야함
            TakeOffEffect(equipItemList[_count]);
            theInven.EquipToInventory(equipItemList[_count]);
            equipItemList[_count] = _item;
        }
        EquipEffect(_item);
        ShowText();
    }

    public void EquipItem(Item _item)
    {
        string temp = _item.itemID.ToString();
        temp = temp.Substring(0, 3);
        switch (temp)
        {
            case "200": // 무기
                EquipItemCheck(WEAPON, _item);
                break;
            case "201": // 반지
                EquipItemCheck(RING, _item);
                break;
            case "202": // 아뮬렛
                EquipItemCheck(AMULT, _item);
                break;
        }
    }

    public void ClearEquip()
    {
        Color color = img_slots[0].color;
        color.a = 0f;

        for(int i = 0; i < img_slots.Length; i++)
        {
            img_slots[i].sprite = null;
            img_slots[i].color = color;
        }
    }

    public void ShowEquip()
    {
        Color color = img_slots[0].color;
        color.a = 1f;

        for(int i =0; i < img_slots.Length; i++)
        {
            if(equipItemList[i].itemID != 0)
            {
                img_slots[i].sprite = equipItemList[i].itemIcon;
                img_slots[i].color = color;
            }
        }
    }

    private void EquipEffect(Item _item)
    {
        thePlayerStat.atk += _item.atk;
        thePlayerStat.def += _item.def;

        added_atk += _item.atk;
        added_def += _item.def;
    }

    private void TakeOffEffect(Item _item)
    {
        thePlayerStat.atk -= _item.atk;
        thePlayerStat.def -= _item.def;

        added_atk -= _item.atk;
        added_def -= _item.def;
    }

    public void ShowText()
    {
        if(added_atk == 0)
        {
            text[ATK].text = thePlayerStat.atk.ToString();
        }
        else
        {
            text[ATK].text = thePlayerStat.atk.ToString() + "(+" + added_atk + ")";
        }

        if(added_def == 0)
        {
            text[DEF].text = thePlayerStat.def.ToString();
        }
        else
        {
            text[DEF].text = thePlayerStat.def.ToString() + "(+" + added_def + ")";
        }

        text[HP].text = thePlayerStat.hp.ToString();
        text[LV].text = thePlayerStat.character_Lv.ToString();
    }

    // Update is called once per frame
    void Update () 
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            activated = !activated;

            if (activated)
            {
                go.SetActive(true);
                selectedSlot = 0;
                ClearEquip();
                ShowEquip();
                ShowText();
            }
            else
            {
                go.SetActive(false);
                ClearEquip();
            }
        }
	}
}
