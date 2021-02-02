using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Action : MonoBehaviour
{
    Rigidbody2D rigid;
    float h;
    float v;
    Vector3 dirvec;
    GameObject scanObject;
    public GameManager manager;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (vDown && v == 1)
        {
            dirvec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirvec = Vector3.down;
        }
        else if (hDown && h == -1)
        {
            dirvec = Vector3.left;
        }
        else if (hDown && h == 1)
        {
            dirvec = Vector3.right;
        }

        if(Input.GetButtonDown("Jump") && scanObject != null)
        {
            manager.Action(scanObject);
        }
        
    }

    void FixedUpdate()
    {
        //Ray
        Debug.DrawRay(rigid.position, dirvec * 100, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirvec, 200, LayerMask.GetMask("NPC"));

        if(rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}
