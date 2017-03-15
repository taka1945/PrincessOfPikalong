using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statue : MonoBehaviour {
    bool inTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space) && inTrigger)
        {
            SceneManager.LoadScene(3);
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
