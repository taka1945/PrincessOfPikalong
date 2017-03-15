using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItemDoor : MonoBehaviour {
    
    private DialogueManager dMan;
    GameObject Door;
    GameObject DoorToButton;

    public string[] failDialogueLines;
    public string[] dialogueLines;

    private Inventory theInv;
    public int[] requiredItemsID;
    private int acquiredItems;

    bool inTrigger;
    // Use this for initialization
    void Start () {
        dMan = FindObjectOfType<DialogueManager>();
        theInv = FindObjectOfType<Inventory>();
        Door = GameObject.Find("Door");
        DoorToButton = GameObject.Find("DoorToButton");

        acquiredItems = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (inTrigger && Input.GetKeyUp(KeyCode.Space))
        {
            //dMan.showBox(dialogue);
            for (int i = 0; i < requiredItemsID.Length; i++)
            {
                if (theInv.CheckItemByID(requiredItemsID[i]))
                {
                    acquiredItems++;
                }
            }

            if (acquiredItems != requiredItemsID.Length)
            {
                acquiredItems = 0;
                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = failDialogueLines;
                    dMan.currentLine = 0;
                    dMan.showDialog();
                }
            }
            else
            {
                acquiredItems = requiredItemsID.Length;
                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.showDialog();
                }
                theInv.ResetInventory();
            }
        }

        if (acquiredItems == requiredItemsID.Length)
        {
            Destroy(Door);
            Destroy(DoorToButton);
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
