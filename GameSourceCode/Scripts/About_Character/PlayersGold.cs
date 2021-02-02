using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersGold : MonoBehaviour
{
    public Text Gold_Text;
    private Player_Stat theStat;
    // Start is called before the first frame update
    void Start()
    {
        theStat = FindObjectOfType<Player_Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        Gold_Text.text = theStat.Gold.ToString();
    }
}
