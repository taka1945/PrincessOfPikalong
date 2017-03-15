using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessCheckingItem : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMan;
    private QuestManager theQM;
    private BoxCollider2D box;

    public string[] dialogueLines;

    private Inventory theInv;
    public int[] requiredItemsID;
    private int acquiredItems;

    public int questNumber;

    bool inTrigger;
    // Use this for initialization
    void Start () {
        dMan = FindObjectOfType<DialogueManager>();
        theInv = FindObjectOfType<Inventory>();
        theQM = FindObjectOfType<QuestManager>();
        box = GetComponent<BoxCollider2D>();

        acquiredItems = 0;
        box.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (theQM.questComplete[questNumber])
        {
            box.enabled = true;
        }

        if (!dMan.dialogActive && acquiredItems == requiredItemsID.Length)
            transform.parent.GetComponent<Princess>().canMove = true;

        if (inTrigger && Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < requiredItemsID.Length; i++)
            {
                if (theInv.CheckItemByID(requiredItemsID[i]))
                {
                    acquiredItems++;
                }
            }
            Debug.Log(acquiredItems);
            if (acquiredItems == requiredItemsID.Length)
            {
                acquiredItems = requiredItemsID.Length;
                theInv.ResetInventory();
                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.showDialog();
                }

            }
            else
                acquiredItems = 0;

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inTrigger = false;
        }
    }
}
