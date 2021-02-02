using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcollisoncheck : MonoBehaviour 
{
    public Dialogue dialogue_Letitia;
    public Dialogue dialogue_Seren;

    public bool isLetitia = false;
    public bool isSeren = false;

    private DataBaseManager theDB;
    private Inventory theInven;
    private Dialog_Manager theDM;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<DataBaseManager>();
        theInven = FindObjectOfType<Inventory>();
        theDM = FindObjectOfType<Dialog_Manager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //레티시아
        if(collision.gameObject.name == "NPC_Latitia")
        {
            isLetitia = true;
        }

        if(collision.gameObject.name == "NPC_Latitia" && Input.GetKey(KeyCode.G) && !flag)
        {
            isLetitia = true;
            theDB.selected_Item_ID = 10003;
            theInven.useItem();
            StartCoroutine(LetitiaEventCoroutine());
            flag = true;
        }
        
        //세렌
        if(collision.gameObject.name == "NPC_Seren")
        {
            isSeren = true;
        }

        if(collision.gameObject.name == "NPC_Seren" && Input.GetKey(KeyCode.G) && !flag)
        {
            isSeren = true;
            theDB.selected_Item_ID = 10004;
            theInven.useItem();
            StartCoroutine(SerenEventCoroutine());
            flag = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "NPC_Latitia")
        {
            isLetitia = false;
            theDB.selected_Item_ID = 0;
            flag = false;
        }

        if(collision.gameObject.name == "NPC_Seren")
        {
            isSeren = false;
            theDB.selected_Item_ID = 0;
            flag = false;
        }
    }

    IEnumerator LetitiaEventCoroutine()
    {
        theDM.ShowDialogue(dialogue_Letitia);
        yield return new WaitUntil(()=> !theDM.talking);
    }

    IEnumerator SerenEventCoroutine()
    {
        theDM.ShowDialogue(dialogue_Seren);
        yield return new WaitUntil(()=> !theDM.talking);
    }
}
