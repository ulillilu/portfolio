using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour {

    public BoxCollider2D bound;
    public string boundName;

    private Main_Camera theCamera;

 // Use this for initialization
    void Start ()
    {
        bound = GetComponent<BoxCollider2D>(); 
        theCamera = FindObjectOfType<Main_Camera>();
    }
 
 // Update is called once per frame
    void Update ()
    {
  
    }

    public void SetBound()
    {
        if(theCamera != null)
        {
            theCamera.SetBound(bound);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        theCamera.SetBound(bound);
    }
}
