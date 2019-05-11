using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        // add in the script to control the outlining when pointing at object
        if (other.gameObject.name == "PointDot")
        {
            Debug.Log("outlining");
            //this.GetComponent<Outline>().OutlineWidth = 5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PointDot")
        {
            Debug.Log("finish outlining");
            //this.GetComponent<Outline>().OutlineWidth = 0f;
        }
    }
}
