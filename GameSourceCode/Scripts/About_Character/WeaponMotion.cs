using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems; 

[RequireComponent(typeof(Animator))]
public class WeaponMotion : MonoBehaviour
{
    public static WeaponMotion instance;
    public bool isAttacking;

    public GameObject attackobject;

    Camera localCamera;

    [HideInInspector]
    public Animator animator;

    float positiveSlope;
    float negativeSlope;

    public float qx;
    public float qy;

    private AudioManager theAudio;

    public bool activeAttack = false;
    public string weaponSound;

    enum Quadrant
    {
        East,
        South,
        West,
        North
    }

    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        localCamera = Camera.main;
        isAttacking = false;
        theAudio = FindObjectOfType<AudioManager>();

        Vector2 lowerLeft = localCamera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 upperRight = localCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 upperLeft = localCamera.ScreenToWorldPoint(new Vector2(0, Screen.height));
        Vector2 lowerRight = localCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0));

        positiveSlope = GetSlope(lowerLeft, upperRight);
        negativeSlope = GetSlope(upperLeft, lowerRight);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !activeAttack)
        {
            if(!EventSystem.current.IsPointerOverGameObject())
            {  
                isAttacking = true;
                StartCoroutine(attackActive());
            }
            // isAttacking = true;
            // StartCoroutine(attackActive());
        }
        UpdateState();
    }

    IEnumerator attackActive()
    {
        attackobject.SetActive(true);
        activeAttack = true;
        yield return new WaitForSeconds(0.6f);
        attackobject.SetActive(false);
        attackobject.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        attackobject.SetActive(false);
        activeAttack = false;
    }

    void UpdateState()
    {
        if (isAttacking)
        {
            Vector2 quadrantVector;
            Quadrant quadEnum = GetQuadrant();

            switch (quadEnum)
            {
                case Quadrant.East:
                    quadrantVector = new Vector2(1.0f, 0.0f);
                    break;
                case Quadrant.South:
                    quadrantVector = new Vector2(0.0f, -1.0f);
                    break;
                case Quadrant.West:
                    quadrantVector = new Vector2(-1.0f, 0.0f);
                    break;
                case Quadrant.North:
                    quadrantVector = new Vector2(0.0f, 1.0f);
                    break;
                default:
                    quadrantVector = new Vector2(0.0f, 0.0f);
                    break;
            }
            theAudio.Play(weaponSound);
            animator.SetBool("isAttack", true);
            animator.SetFloat("AttackXDir", quadrantVector.x);
            animator.SetFloat("AttackYDir", quadrantVector.y);
            qx = quadrantVector.x;
            qy = quadrantVector.y;

            isAttacking = false;
        }

        else
        {
            animator.SetBool("isAttack", false);
        }
    }

    Quadrant GetQuadrant()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 playerPosition = transform.position;

        bool higherThanPositiveSlopeLine = HigherThanPositiveSlopeLine(Input.mousePosition);
        bool higherThanNegativeSlopeLine = HigherThanNegativeSlopeLine(Input.mousePosition);

        if (!higherThanPositiveSlopeLine && higherThanNegativeSlopeLine)
        {
            return Quadrant.East;
        }
        else if (!higherThanPositiveSlopeLine && !higherThanNegativeSlopeLine)
        {
            return Quadrant.South;
        }
        else if (higherThanPositiveSlopeLine && !higherThanNegativeSlopeLine)
        {
            return Quadrant.West;
        }
        else
        {
            return Quadrant.North;
        }
    }

    float GetSlope(Vector2 pointOne, Vector2 pointTwo)
    {
        return (pointTwo.y - pointOne.y) / (pointTwo.x - pointOne.x);
    }

    bool HigherThanPositiveSlopeLine(Vector2 inputPosition)
    {
        Vector2 playerPosition = gameObject.transform.position;
        Vector2 mousePosition = localCamera.ScreenToWorldPoint(inputPosition);

        // solve for b
        float yIntercept = playerPosition.y - (positiveSlope * playerPosition.x);

        // solve for b
        float inputIntercept = mousePosition.y - (positiveSlope * mousePosition.x);

        return inputIntercept > yIntercept;
    }

    bool HigherThanNegativeSlopeLine(Vector2 inputPosition)
    {
        Vector2 playerPosition = gameObject.transform.position;
        Vector2 mousePosition = localCamera.ScreenToWorldPoint(inputPosition);

        // solve for b
        float yIntercept = playerPosition.y - (negativeSlope * playerPosition.x);

        // solve for b
        float inputIntercept = mousePosition.y - (negativeSlope * mousePosition.x);

        return inputIntercept > yIntercept;
    }
}
