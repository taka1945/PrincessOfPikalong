using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuestTrigger : MonoBehaviour {
    private QuestManager theQM;

    public int questNumber;
    public bool startQuest;
    public bool endQuest;

    object[] sprites;
    public SpriteRenderer theSpriteRenderer;

    bool inTrigger;
	// Use this for initialization
	void Start () {
        theQM = FindObjectOfType<QuestManager>();
        sprites = Resources.LoadAll("Items/fantasy-tileset");
        if (SceneManager.GetActiveScene().buildIndex == 7)
            theSpriteRenderer = GameObject.Find("Key container").GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (theQM.questComplete[questNumber])
            gameObject.SetActive(false);

        

        if (inTrigger && Input.GetKeyUp(KeyCode.Space))
        {
            if (!theQM.questComplete[questNumber])
            {
                if (startQuest && !theQM.quest[questNumber].gameObject.activeSelf)
                {
                    theQM.quest[questNumber].gameObject.SetActive(true);
                    theQM.quest[questNumber].startQuest();
                    if (questNumber == 1 && SceneManager.GetActiveScene().buildIndex == 7)
                    {
                        theSpriteRenderer.sprite = (Sprite)sprites[34];
                    }
                }

                if (endQuest && theQM.quest[questNumber].gameObject.activeSelf)
                {
                    theQM.quest[questNumber].endQuest();
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
