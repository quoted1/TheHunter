using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTargetController : MonoBehaviour
{

    public GameObject gameControllerObj;
    public List<GameObject> targetObjects;
    public int totalTargets = 8;
    public int currentHitTargets = 7;

    private void Start()
    {
        foreach (Transform Child in this.transform)
        {
            targetObjects.Add(Child.gameObject);
        }
    }

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

    public void ResetGame()
    {
        currentHitTargets = 0;
        foreach (GameObject X in targetObjects)
        {
            Debug.Log("resetting");
            X.SetActive(true);
        }
    }
}
