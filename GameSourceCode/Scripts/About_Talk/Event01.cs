using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event01 : MonoBehaviour
{
    [SerializeField]
    public Choice choice;

    public Dialogue dialogue_1;
    public Dialogue dialogue_2;

    private Dialog_Manager TheDM;
    private ChoiceManager theChoice;
    private DataBaseManager theDB;

    private bool flag;
    
    // Start is called before the first frame update
    void Start()
    {
        TheDM = FindObjectOfType<Dialog_Manager>();
        theChoice = FindObjectOfType<ChoiceManager>();
        theDB = FindObjectOfType<DataBaseManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if(!flag && Input.GetKey(KeyCode.Space) && !theDB.has_event01)
        {
            flag = true;
            StartCoroutine(EventCoroutine());
            theDB.has_event01 = true;
        }

    }

    IEnumerator EventCoroutine()
    {
        TheDM.ShowDialogue(dialogue_1);

        yield return new WaitUntil(()=> !TheDM.talking);

        theChoice.ShowChoice(choice);

        yield return new WaitUntil(() => !theChoice.choiceIng);
        Debug.Log(theChoice.GetResult());

        TheDM.ShowDialogue(dialogue_2);

        yield return new WaitUntil(()=> !TheDM.talking);

    }
}
