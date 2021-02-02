using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public string atkSound;

    private Player_Stat thePlayerStat;
    public GameObject target;//데미지 출력 장소
    public AudioManager theAudio;

    // Start is called before the first frame update
    void Start()
    {
        thePlayerStat = FindObjectOfType<Player_Stat>();
        theAudio = FindObjectOfType<AudioManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && collision is BoxCollider2D)
        {
            int dmg = collision.gameObject.GetComponent<Enemy_Stat>().Hit(thePlayerStat.atk);
            thePlayerStat.currentGage += 1;
            theAudio.Play(atkSound);
            FloatingTextManager.instance.CreateFloatingText(target.transform.position, dmg + "!!");
        }
    }
}
