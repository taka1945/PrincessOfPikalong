using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public int questNumber;

    private QuestManager theQM;

    public string itemName;
    public int itemID;

    private Inventory inv;

    bool inTrigger;
	// Use this for initialization
	void Start () {
        theQM = FindObjectOfType<QuestManager>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inTrigger && Input.GetKeyUp(KeyCode.Space))
        {
            if (!theQM.questComplete[questNumber] && theQM.quest[questNumber].gameObject.activeSelf)
            {
                theQM.itemCollected = itemName;
                Destroy(gameObject);
                inv.AddItem(itemID);
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
