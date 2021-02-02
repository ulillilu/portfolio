using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDeleteButton : MonoBehaviour
{
    private Inventory inven;
    // Start is called before the first frame update
    void Start()
    {
        inven = FindObjectOfType<Inventory>();

    }

    public void deleteItem()
    {
        inven.deleteItem();
    }
}
