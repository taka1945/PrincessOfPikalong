using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiniStartPoint : MonoBehaviour {
    private PlayerController thePlayer;
    private CameraController theCamera;

    public Vector2 startDirection;

    public string pointName;

    public GameObject thePortalName;
    private LoadNewMiniMap thePortal;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        thePortal = thePortalName.GetComponent<LoadNewMiniMap>();

        if (thePlayer.startPoint == pointName && thePortal.isTransfered)
        {
            Debug.Log(thePortal.isTransfered);
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);

            thePortal.isTransfered = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<PlayerController>();
        }

        if (thePlayer.startPoint == pointName && thePortal.isTransfered)
        {
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);

            thePortal.isTransfered = false;
        }
 
    }
}
