using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float destroyTime;
    [SerializeField] Animation anim;

    void Start()
    {
        anim.Play();
        Destroy(gameObject, destroyTime);
    }

    // public float textSpeed;
    // public float destroyTime;

    // public Text text;

    // private Vector3 vector;

    // // Update is called once per frame
    // void Update()
    // {
    //     vector.Set(0, textSpeed*Time.deltaTime, 0);
    //     text.transform.position = vector;

    //     destroyTime -= Time.deltaTime;

    //     if(destroyTime <= 0)
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }
}
