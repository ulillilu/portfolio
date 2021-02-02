using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStartObject : MonoBehaviour
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
        BGM.Play(playMusicTrack);
        BGM.SetVolumn(0.15f);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
