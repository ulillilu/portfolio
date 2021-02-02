using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemName : MonoBehaviour
{
    public Text itemName_Text;
    public Text itemDes_Text;
    private DataBaseManager theDB;
    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<DataBaseManager>();
    }

    // Update is called once per frame 
    void Update()
    {
        itemName_Text.text = theDB.selected_Item_Name.ToString();
        itemDes_Text.text = theDB.selected_Item_Des.ToString();
    }
}
