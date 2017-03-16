using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class QuestManager : MonoBehaviour {
    public QuestObject[] quest;
    public bool[] questComplete;

    public DialogueManager theDM;

    public string itemCollected;
	// Use this for initialization
	void Start () {
        questComplete = new bool[quest.Length];
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    public void showQuestText(string questText)
    {
        theDM.dialogLines = new string[1];
        theDM.dialogLines[0] = questText;

        theDM.currentLine = 0;
        theDM.showDialog();
    }
}
