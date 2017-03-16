using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    GameObject pauseMenu;
    bool paused;
    bool muted;
    public Text muteText;
    //Button resumeButton;

    private static bool pauseMenuExists;

    private Inventory theInv;
	// Use this for initialization
	void Start () {
        paused = false;
        pauseMenu = GameObject.Find("Pause Menu");
        theInv = FindObjectOfType<Inventory>();

        //resumeButton = GameObject.Find("Resume").GetComponent<Button>();
        if (!pauseMenuExists)
        {
            pauseMenuExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if (muted)
        {
            AudioListener.volume = 0;
            muteText.text = "Unmute";
        }
        else
        {
            AudioListener.volume = 1;
            muteText.text = "Mute";
        }
	}

    public void Resume()
    {
        paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        theInv.ResetInventory();
        paused = false;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("currentSceneSave", SceneManager.GetActiveScene().buildIndex);
    }

    public void Load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentSceneSave"));
        paused = false;
    }

    public void Mute()
    {
        muted = !muted;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
