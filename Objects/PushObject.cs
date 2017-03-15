using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour {

    private Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForPlayerPush();
    }

    void CheckForPlayerPush()
    {
        //int layerMask = 1 << 8;
        //layerMask = ~layerMask;
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + new Vector3(0.0f, 0.7f, 0.0f), Vector2.up);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + new Vector3(0.0f, -0.7f, 0.0f), -Vector2.up);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0.0f, 0.0f), Vector2.right);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-0.7f, 0.0f, 0.0f), -Vector2.right);

        //RaycastHit2D hitDown = Physics2D.Raycast(transform.position + new Vector3(0.0f, -0.7f, 0.0f), transform.TransformDirection(Vector2.down), Mathf.Infinity, layerMask);
        //RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0.0f, 0.0f), transform.TransformDirection(Vector2.right), Mathf.Infinity, layerMask);
        //RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-0.7f, 0.0f, 0.0f), transform.TransformDirection(Vector2.left), Mathf.Infinity, layerMask);

        if (hitUp.collider.gameObject.name == "Player" || hitRight.collider.gameObject.name == "Player" || hitLeft.collider.gameObject.name == "Player" || hitDown.collider.gameObject.name == "Player")
        {
            body.isKinematic = false;
            //Debug.Log(hitUp.collider.gameObject.name);
            //Debug.Log(hitDown.collider.gameObject.name);
           // Debug.Log(hitRight.collider.gameObject.name);
            //Debug.Log(hitLeft.collider.gameObject.name);
        }
        else
        {
            body.isKinematic = true;
            body.velocity = Vector2.zero;
        }

    }
}
