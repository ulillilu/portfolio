using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickUp : MonoBehaviour
{

    public int itemID;
    public int _count;
    private AudioManager theAudio;
    private Inventory theInven;
    public string pickUpSound;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.Z) && collision.gameObject.tag == "Player")
        {
            theInven.getAnItem(itemID, _count);
            theAudio.Play(pickUpSound);
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        theInven = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
