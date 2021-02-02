using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    [SerializeField]

    public Dialogue dialogue_Letitia;
    private Dialog_Manager theDM;

    public string[] var_name;
    public float[] var;
    public string[] switch_name;
    public bool[] switches;
    private Player_Stat theStat;
    private NPCcollisoncheck theNPC;

    public List<Item> itemList = new List<Item>();

    // Event01이 실행된적 있는지 저장
    public bool has_event01 = false;
    public bool has_event001 = false;
    public bool has_event002 = false;
    public bool has_eventLetitia001 = false;
    public bool has_eventLetitia002 = false;
    public bool has_eventLetitia003 = false;
    public bool has_eventLetitia004 = false;
    public bool has_eventSeren001 = false;
    public bool has_eventSeren002 = false;
    public bool has_eventSeren003 = false;
    public bool has_eventSeren004 = false;

    // 선택된 아이템의 아이디를 저장
    public int selected_Item_ID;
    public string selected_Item_Name;
    public string selected_Item_Des;

    public void effectItem(int _itemID)
    {
        switch (_itemID)
        {
            case 10001:
                    if(theStat.hp >= theStat.currentHp + 10)
                    {
                        theStat.currentHp += 10;
                    }
                    else
                    {
                        theStat.currentHp = theStat.hp;
                    }
                break;

            case 10002:
                    if(theStat.gage >= theStat.currentGage + 10)
                    {
                        theStat.currentGage += 10;
                    }
                    else
                    {
                        theStat.currentGage = theStat.gage;
                    }
                break;
                
            case 10003:
                    if(theNPC.isLetitia)
                    {
                        theStat.favorability_Letitia += 1;
                    }
                    else
                    {
                        if(theStat.hp >= theStat.currentHp + 10)
                        {
                            theStat.currentHp += 10;
                        }
                        else
                        {
                            theStat.currentHp = theStat.hp;
                        }
                    }
                break;

            case 10004:
                    if(theNPC.isSeren)
                    {
                        theStat.favorability_Seren += 1;
                    }
                    else
                    {
                        if(theStat.hp >= theStat.currentHp + 10)
                        {
                            theStat.currentHp += 10;
                        }
                        else
                        {
                            theStat.currentHp = theStat.hp;
                        }
                    }
                break;
        }

    }

    void Start()
    {
        theStat = FindObjectOfType<Player_Stat>();   
        theNPC = FindObjectOfType<NPCcollisoncheck>();
        theDM = FindObjectOfType<Dialog_Manager>();

        itemList.Add(new Item(10001, "체력 포션", "체력을 10 회복한다.", Item.ItemType.Use));
        itemList.Add(new Item(10002, "SP 포션", "스킬 게이지를 10 채운다.", Item.ItemType.Use));
        itemList.Add(new Item(10003, "와인", "레티시아가 좋아하는 와인이다.\n선물하려면 레티시아 근처에서\nG를 누르자.\n먹으면 체력을 10 회복한다.", Item.ItemType.Use));
        itemList.Add(new Item(10004, "푸른 방울꽃", "세렌이 좋아하는 꽃이다.\n선물하려면 세렌 근처에서\nG를 누르자.\n먹으면 체력을 10 회복한다.", Item.ItemType.Use));
        itemList.Add(new Item(20001, "롱소드", "기본적인 형태의 장검", Item.ItemType.Equip, 3));
        itemList.Add(new Item(20101, "레더 아머", "가죽으로 만든 가벼운 방어구", Item.ItemType.Equip, 0, 1));
        itemList.Add(new Item(20201, "레티시아의 목걸이", "레티시아가 잃어버린\n목걸이, 다시 가져다 주자.", Item.ItemType.Equip, 0, 1));
    }

}
