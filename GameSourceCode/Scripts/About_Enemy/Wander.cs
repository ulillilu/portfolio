using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float pursuitSpeed; // 추적 속도
    public float wanderSpeed; // 배회 속도
    float currentSpeed; // 위의 둘 중 선택할 현재 속도

    public float directionChangeInterval;

    public bool followPlayer;
    Coroutine moveCoroutine;

    CircleCollider2D circleCollider;
    Rigidbody2D rb2d;
    Animator animator;

    public Transform targetTransform = null;

    public Vector3 endPosition;

    float currentAngle = 0;

    Monster_Attack theMonster;
    private float plusRandomx;
    private float plusRandomy;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentSpeed = wanderSpeed;
        circleCollider = GetComponent<CircleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        theMonster = GetComponent<Monster_Attack>();
        StartCoroutine(WanderRoutine());
    }

    public IEnumerator WanderRoutine()
    {
        while(true)
        {
            ChooseNewEndPoint();

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void ChooseNewEndPoint()
    {
        currentAngle += Random.Range(0, 360);
        currentAngle = Mathf.Repeat(currentAngle, 360);
        endPosition = new Vector3(Random.Range(this.gameObject.transform.position.x-100, this.gameObject.transform.position.x+100), Random.Range(this.gameObject.transform.position.y-100, this.gameObject.transform.position.y+100), 0);
        endPosition += Vector3FromAngle(currentAngle);
    }

    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(inputAngleRadians), Mathf.Sin(inputAngleRadians), 0);
    }

    public IEnumerator Move(Rigidbody2D rigidBodyToMove, float speed)
    {
        float remainingdistance = (transform.position - endPosition).sqrMagnitude;
        while (remainingdistance > float.Epsilon)
        {
            if(targetTransform != null)
            {
                //endPosition = targetTransform.position;
                endPosition = new Vector3(targetTransform.position.x+plusRandomx, targetTransform.position.y+plusRandomy, 0);
            }

            if(rigidBodyToMove != null)
            {
                Vector3 newPosition = Vector3.MoveTowards(rigidBodyToMove.position, endPosition, speed*Time.deltaTime);
                rb2d.MovePosition(newPosition);
                remainingdistance = (transform.position - endPosition).sqrMagnitude;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && followPlayer)
        {
            currentSpeed = pursuitSpeed;

            plusRandomx = Random.Range(-100, 100);
            plusRandomy = Random.Range(-100, 100);

            // Set this variable so the Move coroutine can use it to follow the player.
            targetTransform = collision.gameObject.transform;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            // At this point, endPosition is now player object's transform, ie: will now move towards the player
            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentSpeed = wanderSpeed;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            targetTransform = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((0 < currentAngle && currentAngle <= 360) && theMonster.attaking == false)
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttack", false);
            }
        else if(theMonster.attaking == true)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttack", true);
            }
        else
            {
                animator.SetBool("isAttack", false);
                animator.SetBool("isWalking", false);
            }
    }
}
