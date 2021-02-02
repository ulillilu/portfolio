using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;

    private Player_Movement thePlayer;
    private Main_Camera theCamera;
    private FadeManager theFade;
    BGMManager BGM;

    void Start()
    {
        thePlayer = FindObjectOfType<Player_Movement>();
        theCamera = FindObjectOfType<Main_Camera>();
        theFade = FindObjectOfType<FadeManager>();
        BGM = FindObjectOfType<BGMManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.V))
        {
            BGM.Stop();
            this.gameObject.SetActive(true);
            StartCoroutine(TransferCoroutine());
        }

        // if (collision.gameObject.name == "Player_Swordman")
        // {
        //     StartCoroutine(TransferCoroutine());
        // }
    }

    IEnumerator TransferCoroutine()
    {
        theFade.FadeOut();
        yield return new WaitForSeconds(1f);
        thePlayer.currentMapName = transferMapName;
        SceneManager.LoadScene(transferMapName);
        theFade.FadeIn();
        yield return new WaitForSeconds(0.5f);
    }    
}