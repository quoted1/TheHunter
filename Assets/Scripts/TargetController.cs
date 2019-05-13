using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    #region

    public GameObject[] CenterRing, MiddleRing, OuterRing;
    public int CenterScore, MiddleScore, OuterScore;
    public GameObject GameController;
    public int Score;

    #endregion

    // Use this for initialization
    void Start() {
        CenterScore = 20;
        MiddleScore = 10;
        OuterScore = 5;
    }

    public void CenterRingHit(GameObject colObj)
    {
        Score = CenterScore;
        GameController.GetComponent<ScoreController>().ScoreUp(Score);
        //Debug.Log("score up 20");
        StartCoroutine(HideColObject(colObj));
    }
    public void MiddleRingHit(GameObject colObj)
    {
        Score = MiddleScore;
        GameController.GetComponent<ScoreController>().ScoreUp(Score);
        //Debug.Log("score up 10");
        StartCoroutine(HideColObject(colObj));
    }
    public void OuterRingHit(GameObject colObj)
    {
        Score = OuterScore;
        GameController.GetComponent<ScoreController>().ScoreUp(Score);
        //Debug.Log("score up 5");
        StartCoroutine(HideColObject(colObj));
    }

    private IEnumerator HideColObject(GameObject colObj)
    {
        //Debug.Log("hiding hit target");

        colObj.GetComponent<Renderer>().enabled = false;
        colObj.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(5f);
        //Debug.Log("hiding hit target");

        colObj.GetComponent<Renderer>().enabled = true;
        colObj.GetComponent<Collider>().enabled = true;
    }

    



}
