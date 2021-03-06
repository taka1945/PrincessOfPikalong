﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {
    public int questNumber;

    public QuestManager theQM;

    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isItemQuest)
        {
            if (theQM.itemCollected == targetItem)
            {
                theQM.itemCollected = null;
                endQuest();
            }
        }
	}

    public void startQuest()
    {
        theQM.showQuestText(startText);
    }

    public void endQuest()
    {
        theQM.showQuestText(endText);
        theQM.questComplete[questNumber] = true;
        gameObject.SetActive(false);
    }
}
