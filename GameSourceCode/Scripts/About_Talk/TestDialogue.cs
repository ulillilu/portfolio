using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;
    private Dialog_Manager theDM;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<Dialog_Manager>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player_Swordman")
        {
            theDM.ShowDialogue(dialogue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
