using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour {

    private Bound[] bounds;
    private Player_Movement thePlayer;
    private Main_Camera theCamera;
    private FadeManager theFade;
    private Dialog_Manager theDM;
    private Menu theMenu;
    private Camera cam;

    public void LoadStart()
    {
        StartCoroutine(LoadWaitCoroutine());
    }

    IEnumerator LoadWaitCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        thePlayer = FindObjectOfType<Player_Movement>();
        bounds = FindObjectsOfType<Bound>();
        theCamera = FindObjectOfType<Main_Camera>();
        theFade = FindObjectOfType<FadeManager>();
        theMenu = FindObjectOfType<Menu>();
        cam = FindObjectOfType<Camera>();

        Color color = thePlayer.GetComponent<SpriteRenderer>().color;
        color.a = 1f;
        thePlayer.GetComponent<SpriteRenderer>().color = color;

        theCamera.target = GameObject.Find("Player_Swordman");
        theMenu.GetComponent<Canvas>().worldCamera = cam;
        
        for(int i = 0; i < bounds.Length; i++)
        {
            if(bounds[i].boundName == thePlayer.currentMapName)
            {
                bounds[i].SetBound();
                break;
            }
        }

        theFade.FadeIn();
    }
	
}
