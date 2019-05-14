using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTargetController : MonoBehaviour
{

    public GameObject gameControllerObj;
    public int totalTargets = 8;
    public int currentHitTargets = 7;

    public void TargetHit(GameObject colObj)
    {
        currentHitTargets++;
        colObj.SetActive(false);
        if (currentHitTargets == totalTargets)
        {
            //game finished
            Debug.Log("found em all");
            gameControllerObj.GetComponent<ScoreController>().StopTimer();
            gameControllerObj.GetComponent<ScoreController>().EndGame();
        }
    }
}
