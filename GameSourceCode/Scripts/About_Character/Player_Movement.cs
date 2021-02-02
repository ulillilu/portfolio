using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Animator animator;
    public string currentMapName; 
    //public string currentSceneName;

    Rigidbody2D rb2D;
    BoxCollider2D boxCollider;
    SpriteRenderer sr;
    public GameManager manager;
    public Dialog_Manager dialog_Manager;
    public ChoiceManager choicemanager;
    private WeaponMotion theWeapon;

    public AudioManager theAudio;
    private SaveNLoad theSaveNLoad;
    public string walk_sound;

    private ShopOpen So;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        theWeapon = FindObjectOfType<WeaponMotion>();
        theSaveNLoad = FindObjectOfType<SaveNLoad>();
        So = FindObjectOfType<ShopOpen>();
    }

    void Update()
    {
        sr.sortingOrder = Mathf.RoundToInt(transform.position.y)*-1;
        UpdateState();
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }
    
    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        if(manager.isAction | dialog_Manager.talking | choicemanager.choiceIng | theWeapon.activeAttack | currentMapName == "Title" | So.notMove)
        {
            movement.x = 0;
            movement.y = 0;
            rb2D.velocity = movement * 0;
        }
    
        else
        {
            rb2D.velocity = movement * movementSpeed;
        }

    }

    private void UpdateState()
    {
        if(Input.GetKeyDown(KeyCode.F9))
        {
            // 불러오기
            theSaveNLoad.CallLoad();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.D))
        {
            theAudio.Play(walk_sound);
            theAudio.SetLoop(walk_sound);
        }
        // 줍기
        if(Input.GetKey(KeyCode.Z))
        {
            movementSpeed = 0;
            animator.SetBool("isWalking", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isPick", true);
        }
        // 줍기
        if(Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool("isPick", false);
        }

        if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRun", false);
            theAudio.Stop(walk_sound);
        }

        else if((!Mathf.Approximately(movement.x, 0) | !Mathf.Approximately(movement.y, 0)) && Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 1000;
            animator.SetBool("isRun", true);
            animator.SetBool("isWalking", false);
        }

        else
        {
            movementSpeed = 300;
            animator.SetBool("isWalking", true);
            animator.SetBool("isRun", false);
            animator.SetBool("isPick", false);
        }

        animator.SetFloat("xDir", movement.x);
        animator.SetFloat("yDir", movement.y);
        
    }
}