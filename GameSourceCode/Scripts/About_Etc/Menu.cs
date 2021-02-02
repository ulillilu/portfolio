using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject go;
    public AudioManager theAudio;

    public string call_sound;
    public string cancel_sound;

    private Player_Movement theMove;
    private BGMManager theBGM;
    private bool activated;
    
    // Start is called before the first frame update
    void Start()
    {
        theMove = FindObjectOfType<Player_Movement>();
        theBGM = FindObjectOfType<BGMManager>();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        activated = false;
        go.SetActive(false);
        Time.timeScale = 1;
        theAudio.Play(cancel_sound);
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
        theBGM.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            activated = !activated;

            if(activated)
            {
                go.SetActive(true);
                Time.timeScale = 0;
                theAudio.Play(call_sound);
            }
            else
            {
                go.SetActive(false);
                Time.timeScale = 1;
                theAudio.Play(cancel_sound);
            }
        }
        
    }
}
