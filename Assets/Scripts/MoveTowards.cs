using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour {

    public Transform targetObj;

    public float movementSpeed;

    //formovement
    public bool moving;

	// Use this for initialization
	void Start () {
        moving = false;
        movementSpeed = 0.01f;
	}
	
	void Update () {
        if (moving == true)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, targetObj.position, movementSpeed);
        }

        float thisX = this.gameObject.transform.position.x;
        float thisY = this.gameObject.transform.position.y;

        float targetX = targetObj.transform.position.x;
        float targetY = targetObj.transform.position.y;

        if (Mathf.Approximately(thisX, targetX) && Mathf.Approximately(thisY, targetY) && moving == true)
        {
            //Debug.Log("reached target");
            moving = false;
        }
    }
}
