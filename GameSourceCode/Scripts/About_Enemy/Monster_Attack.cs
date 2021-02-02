using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Attack : MonoBehaviour
{
    public float attackDelay; // 공격 유예.
    public string atkSound;
    private Vector2 playerPos; // 플레이어의 좌표값.
    Wander wander;
    private AudioManager theAudio;
    public float inter_MoveWaitTime; // 대기 시간.
    private float current_interMWT;
    public bool attaking = false;
    public bool stopMonster = false;
    private Player_Stat thePlayerStat;


    void Start()
    {
        wander = GetComponent<Wander>();
        theAudio = FindObjectOfType<AudioManager>();
        thePlayerStat = FindObjectOfType<Player_Stat>();
        current_interMWT = inter_MoveWaitTime;
    }

	// Update is called once per frame
	void Update () 
    {
        current_interMWT -= Time.deltaTime;
        if(current_interMWT <= 0)
        {
            current_interMWT = inter_MoveWaitTime;

            if (NearPlayer())
            {
                Flip();
                return;
            }

        }
	}

    private void Flip()
    {
        Vector3 flip = transform.localScale;
        if (playerPos.x > this.transform.position.x)
            flip.x = -1f;
        else
            flip.x = 1f;
        this.transform.localScale = flip;
        attaking = true;
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(attackDelay);
        theAudio.Play(atkSound);
        if (NearPlayer())
            thePlayerStat.Hit(GetComponent<Enemy_Stat>().atk);
            attaking = false;
    }

    private bool NearPlayer()
    {
        if(wander.targetTransform != null)
        {
            playerPos = wander.endPosition;

            if (Mathf.Abs(Mathf.Abs(playerPos.x) - Mathf.Abs(this.transform.position.x)) <= 100)
            {
                if (Mathf.Abs(Mathf.Abs(playerPos.y) - Mathf.Abs(this.transform.position.y)) <= 100)
                {
                    return true;
                }
            }
            if (Mathf.Abs(Mathf.Abs(playerPos.y) - Mathf.Abs(this.transform.position.y)) <= 100)
            {
                if (Mathf.Abs(Mathf.Abs(playerPos.x) - Mathf.Abs(this.transform.position.x)) <= 100)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
