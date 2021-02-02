using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //한번에 출력 가능한 문장 수 늘리기
    [TextArea(1, 4)]
    public string[] sentences;
    public string[] Name;
    public Sprite[] sprites;
    public Sprite[] dialogueWindows;
}
