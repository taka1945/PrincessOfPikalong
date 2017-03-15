using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesNoQuestion : MonoBehaviour {

    private DialogueManager dMan;

    public string[] dialogueLines;
    
    public bool isYesAnswer;
    bool inTrigger;
    // Use this for initialization
    void Start ()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (inTrigger && Input.GetKeyUp(KeyCode.Space))
        {
            if (isYesAnswer)
            {
                PlayerPrefs.SetInt("yesAmounts", PlayerPrefs.GetInt("yesAmounts") + 1);
                if (!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.showDialog();
                }
            }
            else if (!dMan.dialogActive)
            {
                dMan.dialogLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.showDialog();
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
