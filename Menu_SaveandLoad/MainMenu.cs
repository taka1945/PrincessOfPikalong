using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string exitPoint;

    private PlayerController thePlayer;
    //GameObject canvas;
    //GameObject inv;
    // Use this for initialization

    void Start () {

        Time.timeScale = 0;
        thePlayer = FindObjectOfType<PlayerController>();
        //canvas = GameObject.Find("Canvas");
        //inv = GameObject.Find("Inventory");

        //canvas.SetActive(false);
        //inv.SetActive(false);
        PlayerPrefs.SetInt("loadFromMain", 0);
    }
	
	// Update is called once per frame
	void Update()
    {

    }

    public void StartGame()
    {
        Time.timeScale = 1;
        // canvas.SetActive(true);
        //inv.SetActive(true);
        thePlayer.startPoint = exitPoint;
        PlayerPrefs.SetInt("yesAmounts", 0);
        PlayerPrefs.SetInt("currentSceneSave", 0);
        SceneManager.LoadScene(13);
    }

    public void Load()
    {
        thePlayer.startPoint = exitPoint;
        if (PlayerPrefs.GetInt("currentSceneSave") != 0)
        {
            PlayerPrefs.SetInt("loadFromMain", 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentSceneSave"));
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
