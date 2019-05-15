using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerLink : MonoBehaviour
{
    public GameObject scenecontroller;

    public void ReturnMenuLink()
    {
        scenecontroller.GetComponent<SceneController>().ReturnMenuPress();
    }
}
