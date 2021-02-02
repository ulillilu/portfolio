using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem_Use : MonoBehaviour
{
    private int RandNumID;
    private int RandNumCount;
    private AudioManager theAudio;
    private Inventory theInven;
    public string pickUpSound;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.Z) && collision.gameObject.tag == "Player")
        {
            theInven.getAnItem(10000 + RandNumID, RandNumCount);
            theAudio.Play(pickUpSound);
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        theInven = FindObjectOfType<Inventory>();
        RandNumID = Random.Range(3, 5);
        RandNumCount = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

