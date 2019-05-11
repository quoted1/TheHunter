using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);

        if (col.gameObject.tag == "MenuObj")
        {
            col.gameObject.GetComponentInParent<Text>().color = Color.green;
        }
    }

    private void OncollisionExit(Collision col)
    {
        if (col.gameObject.name == "PlayGameCube")
        {
            col.gameObject.GetComponentInParent<Text>().color = Color.black;
        }
        if (col.gameObject.name == "OverViewCube")
        {
            col.gameObject.GetComponentInParent<Text>().color = Color.black;
        }
        if (col.gameObject.name == "ExitGameCube")
        {
            col.gameObject.GetComponentInParent<Text>().color = Color.black;
        }
    }
}
