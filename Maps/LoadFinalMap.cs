using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinalMap : MonoBehaviour {
    public string exitPoint;

    private PlayerController thePlayer;
    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer == null)
            thePlayer = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            thePlayer.startPoint = exitPoint;
            Debug.Log("yes amount: " + PlayerPrefs.GetInt("yesAmounts"));
            if (PlayerPrefs.GetInt("yesAmounts") >= 3)
            {
                SceneManager.LoadScene(11);
                PlayerPrefs.SetInt("currentSceneSave", 0);
            }
            else
            {
                SceneManager.LoadScene(12);
                PlayerPrefs.SetInt("currentSceneSave", 0);
            }
        }
    }
}
