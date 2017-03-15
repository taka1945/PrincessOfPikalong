using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBlockZone : MonoBehaviour {

    private DialogueManager dMan;
    GameObject block;
    public string[] dialogueLines;
    // Use this for initialization
    void Start ()
    {
        dMan = FindObjectOfType<DialogueManager>();
        block = GameObject.Find("Block");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!dMan.dialogActive)
            {
                dMan.dialogLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.showDialog();
            }
            Destroy(block);
        }
    }
}
