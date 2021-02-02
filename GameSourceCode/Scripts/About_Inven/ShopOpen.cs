using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOpen : MonoBehaviour
{
    public GameObject go;
    public bool notMove = false;
    public Text Hi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.Space) && collision.gameObject.name == "Nox(Shop)")
        {
            go.SetActive(true);
            notMove = true;
            Hi.text = "어서오게.";
        }
    }
}
