using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

    private PlayerController thePlayer;

    public bool keyboardAllow; //only for level 2-2
    public bool checkIfCorrectQuest; //only for level 2-2
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyUp(KeyCode.Return))
        {
            //dBox.SetActive(false);
            //dialogActive = false;
            currentLine++;
        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;

            thePlayer.canMove = true;

            if (checkIfCorrectQuest)
                keyboardAllow = true;
        }

        dText.text = dialogLines[currentLine];
	}

    //public void showBox(string dialog)
    //{
    //    dialogActive = true;
    //    dBox.SetActive(true);
    //    dText.text = dialog;    
    //}

    public void showDialog()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
