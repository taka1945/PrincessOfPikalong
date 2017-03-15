using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCode : MonoBehaviour {

    private KeyboardManager theKM;

    private DialogueManager dMan;
    public string[] failDialogueLines;
    public string[] completedDialogueLines;
    public string[] dialogueLines;
    //public string[] dialogueLines;

    GameObject DoorMain;
    GameObject ExitLevel;

    public string codeToPass;
    private bool inTrigger;
    private bool isFirstTime;
    // Use this for initialization
    void Start () {
        theKM = FindObjectOfType<KeyboardManager>();
        dMan = FindObjectOfType<DialogueManager>();
        DoorMain = GameObject.Find("DoorMain");
        ExitLevel = GameObject.Find("Exit 2-2");

        isFirstTime = true;
        ExitLevel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (inTrigger  && Input.GetKeyUp(KeyCode.Space))
        {
            // Intro text
            if (!dMan.dialogActive && isFirstTime)
            {
                dMan.dialogLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.checkIfCorrectQuest = true;
                dMan.showDialog();
            }

            isFirstTime = false;
            //Show keyboard
            if (dMan.keyboardAllow)
            {
                theKM.keyboardActive = true;
                dMan.keyboardAllow = false;
            }

            //Check if correct input code
            if (!theKM.keyboardActive)
            {
                if (theKM.finalText == codeToPass)
                {
                    if (!dMan.dialogActive)
                    {
                        dMan.dialogLines = completedDialogueLines;
                        dMan.currentLine = 0;
                        dMan.showDialog();
                    }
                    ExitLevel.SetActive(true);
                    Destroy(DoorMain);
                }
                else
                {
                    Debug.Log("here");
                    if (!dMan.dialogActive)
                    {
                        dMan.dialogLines = failDialogueLines;
                        dMan.currentLine = 0;
                        dMan.showDialog();
                    }
                }
            }
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
