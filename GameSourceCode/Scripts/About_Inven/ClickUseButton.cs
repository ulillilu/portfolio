using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickUseButton : MonoBehaviour
{
    private Inventory inven;
    // Start is called before the first frame update
    void Start()
    {
        inven = FindObjectOfType<Inventory>();
    }

    public void useItem()
    {
        inven.useItem();
        inven.ShowItem();
    }
}
