using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    private Player_Movement thePlayer;
    private Main_Camera theCamera;

    void Start()
    {
        theCamera = FindObjectOfType<Main_Camera>();
        thePlayer = FindObjectOfType<Player_Movement>();


        if(startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
    }

    void Update()
    {

    }
}