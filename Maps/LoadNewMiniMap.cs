using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewMiniMap : MonoBehaviour {

    public string exitPoint;

    private PlayerController thePlayer;

    public bool isTransfered;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<PlayerController>();
            isTransfered = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            thePlayer.startPoint = exitPoint;
            isTransfered = true;
        }
    }
}
