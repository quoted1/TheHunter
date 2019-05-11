using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionController : MonoBehaviour {

    public bool holdingArrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bow" && holdingArrow == true)
        {
            //Debug.Log("Arrow and bow connected");
            ArrowManager.Instance.AttachBowToArrow();
        }
    }
}
