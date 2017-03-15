using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public string itemName;
    public int itemID;

    private Inventory inv;

    private DialogueManager dMan;

    public string[] dialogueLines;

    bool inTrigger;
    // Use this for initialization
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && Input.GetKeyUp(KeyCode.Space))
        {
            if (!dMan.dialogActive)
            {
                dMan.dialogLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.showDialog();
            }
            gameObject.SetActive(false);
            inv.AddItem(itemID);
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
