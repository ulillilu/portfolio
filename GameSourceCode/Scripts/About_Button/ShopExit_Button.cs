using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopExit_Button : MonoBehaviour
{
    public GameObject go;
    private ShopOpen So;
    // Start is called before the first frame update
    void Start()
    {
        So = FindObjectOfType<ShopOpen>();
    }
    public void ShopExit()
    {
        go.SetActive(false);
        So.notMove = false;
    }
}
