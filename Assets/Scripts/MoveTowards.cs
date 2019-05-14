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
        movementSpeed = 0.05f;
	}
	
	void Update () {
        if (moving == true)
        {
            this.transform.parent.transform.position = Vector3.MoveTowards(this.transform.parent.transform.position, targetObj.position, movementSpeed);
        }

        float thisX = this.gameObject.transform.position.x;
        float thisY = this.gameObject.transform.position.y;

        float targetX = targetObj.transform.position.x;
        float targetY = targetObj.transform.position.y;

        if (Vector3.Distance(this.transform.parent.transform.position, targetObj.position) < 2f)
        {
            //Debug.Log("reached target");
            moving = false;
        }
    }
}
