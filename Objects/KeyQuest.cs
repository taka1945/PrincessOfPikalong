using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyQuest : MonoBehaviour {

    private DialogueManager dMan;

    public string[] dialogueLines;
    GameObject Keys;

    bool inTrigger;
    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        Keys = GameObject.Find("Keys");
        Keys.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (inTrigger && Input.GetKeyUp(KeyCode.Space))
        {
            //dMan.showBox(dialogue);
            if (!dMan.dialogActive)
            {
                dMan.dialogLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.showDialog();
            }
            Keys.SetActive(true);
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
