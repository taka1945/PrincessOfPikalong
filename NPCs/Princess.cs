using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour {

    public float moveSpeed;

    //private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool princessMoving;
    public Vector2 lastMove;

    public bool canMove;
    //public DialogueManager theDM;

    //public float waitTime;
    //private float waitCounter;
    public float walkTime;
    private float walkCounter;

    //public QuestManager theQM;
    //public Inventory theInven;
    // Use this for initialization
    void Start () {
        //anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        //theDM = FindObjectOfType<DialogueManager>();
        //theQM = FindObjectOfType<QuestManager>();
        //        theInven = GameObject.Find("Inventory").GetComponent<Inventory>();
        //theInven = FindObjectOfType<Inventory>();
        walkCounter = walkTime;
        canMove = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (canMove)
        {
            walkCounter -= Time.deltaTime;
            myRigidbody.velocity = new Vector2(0, moveSpeed);
            lastMove = new Vector2(0, moveSpeed);
            if (walkCounter < 0f)
            {
                canMove = false;
            }
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
