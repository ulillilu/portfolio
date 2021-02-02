using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stat : MonoBehaviour
{
    public static Player_Stat instance;

    public int character_Lv;
    public int[] needExp;
    public int currentExp;

    public int hp;
    public int currentHp;
    public int mp;
    public int currentMp;
    public int gage = 100;
    public int currentGage;

    public int Gold;

    public int atk;
    public int def;
    public int favorability_Letitia; //호감도
    public int favorability_Seren;

    public int recover_hp;
    public int recover_mp;
    public int avd; // 회피율

    public string dmgSound;

    public Slider hpSlider;
    public Slider gageSlider;
    public Slider expSlider;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHp = hp;
        currentMp = mp;
        currentGage = 0;
        currentExp = 0;
    }

    public void Hit(int _enemyAtk)
    {
        int dmg;
        if(def >= _enemyAtk)
        {
            dmg = 1;
        }
        else
        {
            dmg = _enemyAtk - def;
        }
        currentHp -= dmg;

        if(currentHp <= 0)
        {
            Debug.Log("게임오버");
        }
        AudioManager.instance.Play(dmgSound);
        StopAllCoroutines();
        StartCoroutine(HitCoroutine());
    }

    IEnumerator HitCoroutine()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.maxValue = hp;
        gageSlider.maxValue = gage;
        expSlider.maxValue = needExp[character_Lv];

        hpSlider.value = currentHp;
        gageSlider.value = currentGage;
        expSlider.value = currentExp;

        if(currentExp >= needExp[character_Lv])
        {
            character_Lv++;
            hp += character_Lv * 2;
            
            currentHp = hp;
            currentMp = mp;
            atk++;
            def++;

        }
        
    }
}
