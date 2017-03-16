using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour {

    public GameObject keyboardWin;
    public string finalText;
    public bool keyboardActive;

    private PlayerController thePlayer;

    private bool keyboardExists;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        keyboardWin = GameObject.Find("KeyboardWindow");

        if (!keyboardExists)
        {
            keyboardExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (keyboardActive)
        {
            keyboardWin.SetActive(true);
            thePlayer.canMove = false;
        }
        else if (keyboardWin != null)
        {
            keyboardWin.SetActive(false);
        }
	}
}
