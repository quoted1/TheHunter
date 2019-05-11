using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPointDot : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        // add in the script to control the outlining when pointing at object
        if (other.gameObject.tag == "Movementtarget")
        {
            //Debug.Log("outlining");
            //other.gameObject.GetComponent<Outline>().OutlineWidth = 5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Movementtarget")
        {
            //Debug.Log("finish outlining");
            //other.gameObject.GetComponent<Outline>().OutlineWidth = 0f;
        }
    }
}
