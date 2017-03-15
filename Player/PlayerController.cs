using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    //private float currentMoveSpeed;
    //public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    public string startPoint;

    public bool canMove;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;

        lastMove = new Vector2(0, -1f);
    }
	
	// Update is called once per frame
	void Update () {
        playerMoving = false;

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        /* if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
         {
             //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
             myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
             playerMoving = true;
             lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
         }

         if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
         {
             //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
             myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
             playerMoving = true;
             lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
         }

         if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
         {
             currentMoveSpeed = moveSpeed * diagonalMoveModifier;
         }
         else
         {
             currentMoveSpeed = moveSpeed;
         }
         
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }
        */

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveInput != Vector2.zero)
        {
            myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
            playerMoving = true;
            lastMove = moveInput;
        }
        else
            myRigidbody.velocity = Vector2.zero;
       
        if (Time.timeScale != 0 )
        {
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
    }


}
