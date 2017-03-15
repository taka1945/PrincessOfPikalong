using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

    public VolumeController[] vcObjects;

    public float maxVolumeLevel = 1.0f;
    public float currentVolumeLevel;

    private static bool vcExists;
    // Use this for initialization
	void Start () {
        vcObjects = FindObjectsOfType<VolumeController>();

        if (!vcExists)
        {
            vcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (currentVolumeLevel > maxVolumeLevel)
        {
            currentVolumeLevel = maxVolumeLevel;
        }

        for (int i = 0; i < vcObjects.Length; i++)
        {
            vcObjects[i].setAudioLevel(currentVolumeLevel);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
