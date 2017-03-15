using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilController : MonoBehaviour {
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool evilMoving;
    public Vector2 lastMove;

    public float waitTime;
    private float waitCounter;
    public float walkTime;
    private float walkCounter;
    private int walkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    public bool canMove;
    public DialogueManager theDM;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogueManager>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        chooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        canMove = true;
    }

    void Update()
    {
        if (!theDM.dialogActive)
        {
            canMove = true;
        }

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if (evilMoving)
        {
            walkCounter -= Time.deltaTime;
            switch (walkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        evilMoving = false;
                        waitCounter = waitTime;
                    }
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", moveSpeed);
                    lastMove = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        evilMoving = false;
                        waitCounter = waitTime;
                    }
                    anim.SetFloat("MoveX", moveSpeed);
                    anim.SetFloat("MoveY", 0);
                    lastMove = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, - moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        evilMoving = false;
                        waitCounter = waitTime;
                    }
                    anim.SetFloat("MoveY", -moveSpeed);
                    anim.SetFloat("MoveX", 0);
                    lastMove = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        evilMoving = false;
                        waitCounter = waitTime;
                    }
                    anim.SetFloat("MoveX", -moveSpeed);
                    anim.SetFloat("MoveY", 0);
                    lastMove = new Vector2(-moveSpeed, 0);
                    break;
            }
            if (walkCounter < 0f)
            {
                evilMoving = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (waitCounter < 0f)
            {
                chooseDirection();
            }
        }

        anim.SetBool("EvilMoving", evilMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    void chooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        evilMoving = true;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    /* Moving randomly + animation
   void Update () {

       if (evilMoving)
       {
           walkCounter -= Time.deltaTime;
           myRigidbody.velocity = moveDirection;
           if (walkCounter < 0f)
           {
               evilMoving = false;
               waitCounter = waitTime;
               lastMove = new Vector2(moveDirection.x, moveDirection.y);
           }
       }
       else
       {
           waitCounter -= Time.deltaTime;
           if (Mathf.Abs(moveDirection.x) < Mathf.Abs(moveDirection.y))
           {
               myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
           }
           if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
               myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
           myRigidbody.velocity = Vector2.zero;
           if (waitCounter < 0f)
           {
               evilMoving = true;
               walkCounter = walkTime;
               moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
           }
       }

       anim.SetFloat("MoveX", moveDirection.x);
       anim.SetFloat("MoveY", moveDirection.y);
       anim.SetBool("EvilMoving", evilMoving);
       anim.SetFloat("LastMoveX", lastMove.x);
       anim.SetFloat("LastMoveY", lastMove.y);
       */

}


