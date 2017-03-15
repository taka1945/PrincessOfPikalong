using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewMap : MonoBehaviour {
    public int levelToLoad;

    public string exitPoint;

    private PlayerController thePlayer;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (thePlayer == null)
            thePlayer = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            thePlayer.startPoint = exitPoint;
            PlayerPrefs.SetInt("currentSceneSave", SceneManager.GetActiveScene().buildIndex+1);
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
