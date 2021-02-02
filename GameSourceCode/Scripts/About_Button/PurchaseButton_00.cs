using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton_00 : MonoBehaviour
{
    public Text Purchase_Text;
    private Inventory theInven;
    private Player_Stat theStat;

    // Start is called before the first frame update
    void Start()
    {
        theInven = FindObjectOfType<Inventory>();
        theStat = FindObjectOfType<Player_Stat>();
    }

    public void Purchase_00()
    {
        if (theStat.Gold < 500)
        {
            Purchase_Text.text = "골드가 부족하군.";
        }
        else
        {
            theInven.getAnItem(10001, 1);
            Purchase_Text.text = "고맙네.";
            theStat.Gold -= 500;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
