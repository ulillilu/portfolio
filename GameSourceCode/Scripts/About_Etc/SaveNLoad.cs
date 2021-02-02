using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveNLoad : MonoBehaviour {

    [System.Serializable]
    public class Data
    {
        public float playerX;
        public float playerY;
        public float playerZ;

        public int playerLv;
        public int playerHP;
        public int playerMP;

        public int playerGlod;

        public int playerCurrentHP;
        public int playerCurrentMP;
        public int playerCurrentEXP;

        public int playerATK;
        public int playerDEF;

        public int added_atk;
        public int added_def;

        //호감도
        public int favorLetitia;
        public int favorSeren;

        public List<int> playerItemInventory;
        public List<int> playerItemInventoryCount;
        public List<int> playerEquipItem;

        public string mapName;
        //public string sceneName;

        public List<bool> swList;
        public List<string> swNameList;
        public List<string> varNameList;
        public List<float> varNumberList;

        //이벤트 기록
        public bool HasEvent001;
        public bool HasEvent002;
        public bool HasEventLetitia001;
        public bool HasEventLetitia002;
        public bool HasEventLetitia003;
        public bool HasEventLetitia004;
        public bool HasEventSeren001;
        public bool HasEventSeren002;
        public bool HasEventSeren003;
        public bool HasEventSeren004;
    }

    private Player_Movement thePlayer;
    private Player_Stat thePlayerStat;
    private DataBaseManager theDatabase;
    private Inventory theInven;
    private Equipment theEquip;

    public Data data;

    private Vector3 vector;


    public void CallSave()
    {
        theDatabase = FindObjectOfType<DataBaseManager>();
        thePlayer = FindObjectOfType<Player_Movement>();
        thePlayerStat = FindObjectOfType<Player_Stat>();
        theEquip = FindObjectOfType<Equipment>();
        theInven = FindObjectOfType<Inventory>();

        data.playerX = thePlayer.transform.position.x;
        data.playerY = thePlayer.transform.position.y;
        data.playerZ = thePlayer.transform.position.z;

        data.playerLv = thePlayerStat.character_Lv;
        data.playerHP = thePlayerStat.hp;
        data.playerMP = thePlayerStat.mp;
        data.playerCurrentHP = thePlayerStat.currentHp;
        data.playerCurrentMP = thePlayerStat.currentMp;
        data.playerCurrentEXP = thePlayerStat.currentExp;
        data.playerATK = thePlayerStat.atk;
        data.playerDEF = thePlayerStat.def;
        data.added_atk = theEquip.added_atk;
        data.added_def = theEquip.added_def;

        data.playerGlod = thePlayerStat.Gold;

        //호감도
        data.favorLetitia = thePlayerStat.favorability_Letitia;
        data.favorSeren = thePlayerStat.favorability_Seren;

        data.mapName = thePlayer.currentMapName;
        //data.sceneName = thePlayer.currentSceneName;

        //이벤트 기록
        data.HasEvent001 = theDatabase.has_event001;
        data.HasEvent002 = theDatabase.has_event002;
        data.HasEventLetitia001 = theDatabase.has_eventLetitia001;
        data.HasEventLetitia002 = theDatabase.has_eventLetitia002;
        data.HasEventLetitia003 = theDatabase.has_eventLetitia003;
        data.HasEventLetitia004 = theDatabase.has_eventLetitia004;
        data.HasEventSeren001 = theDatabase.has_eventSeren001;
        data.HasEventSeren002 = theDatabase.has_eventSeren002;
        data.HasEventSeren003 = theDatabase.has_eventSeren003;
        data.HasEventSeren004 = theDatabase.has_eventSeren004;

        Debug.Log("기초 데이터 성공");

        data.playerItemInventory.Clear();
        data.playerItemInventoryCount.Clear();
        data.playerEquipItem.Clear();

        for(int i = 0; i < theDatabase.var_name.Length; i++)
        {
            data.varNameList.Add(theDatabase.var_name[i]);
            data.varNumberList.Add(theDatabase.var[i]);
        }
        for (int i = 0; i < theDatabase.switch_name.Length; i++)
        {
            data.swNameList.Add(theDatabase.switch_name[i]);
            data.swList.Add(theDatabase.switches[i]);
        }

        List<Item> itemList = theInven.SaveItem();

        for(int i = 0; i < itemList.Count; i++)
        {
            Debug.Log("인벤토리의 아이템 저장 완료 : " + itemList[i].itemID);
            data.playerItemInventory.Add(itemList[i].itemID);
            data.playerItemInventoryCount.Add(itemList[i].itemCount);
        }

        for(int i = 0; i < theEquip.equipItemList.Length; i++)
        {
            data.playerEquipItem.Add(theEquip.equipItemList[i].itemID);
            Debug.Log("장착된 아이템 저장 완료 : " + theEquip.equipItemList[i].itemID);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/SaveFile.dat");

        bf.Serialize(file, data);
        file.Close();

        Debug.Log(Application.dataPath + "의 위치에 저장했습니다.");

    }

    public void CallLoad()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/SaveFile.dat", FileMode.Open);

        if(file != null && file.Length > 0)
        {
            data = (Data)bf.Deserialize(file);

            theDatabase = FindObjectOfType<DataBaseManager>();
            thePlayer = FindObjectOfType<Player_Movement>();
            thePlayerStat = FindObjectOfType<Player_Stat>();
            theEquip = FindObjectOfType<Equipment>();
            theInven = FindObjectOfType<Inventory>();

            thePlayer.currentMapName = data.mapName;
            //thePlayer.currentSceneName = data.sceneName;

            vector.Set(data.playerX, data.playerY, data.playerZ);
            thePlayer.transform.position = vector;

            thePlayerStat.character_Lv = data.playerLv;
            thePlayerStat.hp = data.playerHP;
            thePlayerStat.mp = data.playerMP;
            thePlayerStat.currentHp = data.playerCurrentHP;
            thePlayerStat.currentMp = data.playerCurrentMP;
            thePlayerStat.currentExp = data.playerCurrentEXP;
            thePlayerStat.atk = data.playerATK;
            thePlayerStat.def = data.playerDEF;

            thePlayerStat.Gold = data.playerGlod;

            //호감도
            thePlayerStat.favorability_Letitia = data.favorLetitia;
            thePlayerStat.favorability_Seren = data.favorSeren;

            theEquip.added_atk = data.added_atk;
            theEquip.added_def = data.added_def;

            //이벤트 기록
            theDatabase.has_event001 = data.HasEvent001;
            theDatabase.has_event002 = data.HasEvent002;
            theDatabase.has_eventLetitia001 = data.HasEventLetitia001;
            theDatabase.has_eventLetitia002 = data.HasEventLetitia002;
            theDatabase.has_eventLetitia003 = data.HasEventLetitia003;
            theDatabase.has_eventLetitia004 = data.HasEventLetitia004;
            theDatabase.has_eventSeren001 = data.HasEventSeren001;
            theDatabase.has_eventSeren002 = data.HasEventSeren002;
            theDatabase.has_eventSeren003 = data.HasEventSeren003;
            theDatabase.has_eventSeren004 = data.HasEventSeren004;

            theDatabase.var = data.varNumberList.ToArray();
            theDatabase.var_name = data.varNameList.ToArray();
            theDatabase.switches = data.swList.ToArray();
            theDatabase.switch_name = data.swNameList.ToArray();

            for(int i = 0; i < theEquip.equipItemList.Length; i++)
            {
                for(int x = 0; x < theDatabase.itemList.Count; x++)
                {
                    if(data.playerEquipItem[i] == theDatabase.itemList[x].itemID)
                    {
                        theEquip.equipItemList[i] = theDatabase.itemList[x];
                        Debug.Log("장착된 아이템을 로드했습니다 : " + theEquip.equipItemList[i].itemID);
                        break;
                    }
                }
            }


            List<Item> itemList = new List<Item>();

            for (int i = 0; i < data.playerItemInventory.Count; i++)
            {
                for (int x = 0; x < theDatabase.itemList.Count; x++)
                {
                    if (data.playerItemInventory[i] == theDatabase.itemList[x].itemID)
                    {
                        itemList.Add(theDatabase.itemList[x]);
                        Debug.Log("인벤토리 아이템을 로드했습니다 : " + theDatabase.itemList[x].itemID);
                        break;
                    }
                }
            }

            for(int i = 0; i < data.playerItemInventoryCount.Count; i++)
            {
                itemList[i].itemCount = data.playerItemInventoryCount[i];
            }

            theInven.LoadItem(itemList);
            theEquip.ShowText();

            RPGGameManager theGM = FindObjectOfType<RPGGameManager>();
            theGM.LoadStart();

            SceneManager.LoadScene(data.mapName);
        }
        else
        {
            Debug.Log("저장된 세이브 파일이 없습니다");
        }


        file.Close();
    }
}
