using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    private FadeManager theFade;
    private AudioManager theAudio;
    private Player_Movement thePlayer;
    private RPGGameManager theGM;
    //카메라 조정 요소
    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        theAudio = FindObjectOfType<AudioManager>();
        thePlayer = FindObjectOfType<Player_Movement>();
        theGM = FindObjectOfType<RPGGameManager>();
    }

    public void StartGame()
    {
        StartCoroutine(GameStartCoroutine());
    }

    IEnumerator GameStartCoroutine()
    {
        theFade.FadeOut();
        yield return new WaitForSeconds(2f);
        Color color = thePlayer.GetComponent<SpriteRenderer>().color;
        color.a = 1f;
        thePlayer.GetComponent<SpriteRenderer>().color = color;
        thePlayer.currentMapName = "Town";

        theGM.LoadStart();
        SceneManager.LoadScene("Town");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
