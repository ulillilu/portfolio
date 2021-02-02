using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stat : MonoBehaviour
{
    public int hp; // 몬스터 총 hp
    public int currentHp; // 몬스터 현재 체력
    public int atk; // 몬스터 공격력
    public int def; // 몬스터 방어력
    public int exp; // 처치시 획득 경험치

    public int getGold;
    Animator animator;
    private Player_Stat thePlayerStat;
    [SerializeField] GameObject RandomItem;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        thePlayerStat = FindObjectOfType<Player_Stat>();
        currentHp = hp;
        getGold = Random.Range(500, 1000);
    }

    public int Hit(int _playerAtk)
    {
        int playerAtk = _playerAtk;
        int dmg;
        if (def >= playerAtk)
        {
            dmg = 1;
        }
        else
        {
            dmg = playerAtk - def;
        }
        StartCoroutine(hurtMotion());
        currentHp -= dmg;
        if(currentHp <= 0)
        {
            StartCoroutine(deathMotion());
        }

        return dmg;
    }

    IEnumerator hurtMotion()
    {
        animator.SetBool("isHurt", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isHurt", false);
    }

    IEnumerator deathMotion()
    {
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
        GameObject clone = Instantiate(RandomItem, this.transform.position, Quaternion.identity);
        thePlayerStat.currentExp += exp;
        thePlayerStat.Gold += getGold;
    }

}
