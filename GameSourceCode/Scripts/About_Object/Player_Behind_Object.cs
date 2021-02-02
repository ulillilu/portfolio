using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behind_Object : MonoBehaviour
{
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // 물체의 크기에 맞춰 -값 조정 필요
        sr.sortingOrder = Mathf.RoundToInt(transform.position.y)*-1 -150;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
