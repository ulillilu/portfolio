using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event002 : MonoBehaviour
{
    [SerializeField]

    public Dialogue dialogue_1;

    private Dialog_Manager TheDM;
    private DataBaseManager theDB;

    private bool flag;
    
    // Start is called before the first frame update
    void Start()
    {
        TheDM = FindObjectOfType<Dialog_Manager>();
        theDB = FindObjectOfType<DataBaseManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(!flag && !theDB.has_event002 && collision.gameObject.tag == "Player")
        {
            flag = true;
            StartCoroutine(EventCoroutine());
            theDB.has_event002 = true;
        }

    }

    IEnumerator EventCoroutine()
    {
        TheDM.ShowDialogue(dialogue_1);
        yield return new WaitUntil(()=> !TheDM.talking);
    }
}
