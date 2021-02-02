﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStopObject : MonoBehaviour
{
    BGMManager BGM;
    public int playMusicTrack;
    // Start is called before the first frame update
    void Start()
    {
        BGM = FindObjectOfType<BGMManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BGM.Stop();
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
