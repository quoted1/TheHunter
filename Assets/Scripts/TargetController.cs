using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    #region

    public GameObject CenterRing, MiddleRing, OuterRing;
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

    public void CenterRingHit()
    {
        Score = CenterScore;
        GameController.GetComponent<ScoreController>().ScoreUp(Score);
        //Debug.Log("score up 20");
        StartCoroutine(HideCenterObject());
    }
    public void MiddleRingHit()
    {
        Score = MiddleScore;
        GameController.GetComponent<ScoreController>().ScoreUp(Score);
        //Debug.Log("score up 10");
        StartCoroutine(HideMiddleObject());
    }
    public void OuterRingHit()
    {
        Score = OuterScore;
        GameController.GetComponent<ScoreController>().ScoreUp(Score);
        //Debug.Log("score up 5");
        StartCoroutine(HideOuterObject());
    }

    private IEnumerator HideCenterObject()
    {
        //Debug.Log("hiding hit target");

        CenterRing.GetComponent<Renderer>().enabled = false;
        CenterRing.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(5f);
        //Debug.Log("hiding hit target");

        CenterRing.GetComponent<Renderer>().enabled = true;
        CenterRing.GetComponent<Collider>().enabled = true;
    }

    private IEnumerator HideMiddleObject()
    {
        //Debug.Log("hiding hit target");

        MiddleRing.GetComponent<Renderer>().enabled = false;
        MiddleRing.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(5f);
       // Debug.Log("hiding hit target");

        MiddleRing.GetComponent<Renderer>().enabled = true;
        MiddleRing.GetComponent<Collider>().enabled = true;
    }

    private IEnumerator HideOuterObject()
    {
        //Debug.Log("hiding hit target");

        OuterRing.GetComponent<Renderer>().enabled = false;
        OuterRing.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(5f);

        //Debug.Log("hiding hit target");

        OuterRing.GetComponent<Renderer>().enabled = true;
        OuterRing.GetComponent<Collider>().enabled = true;
    }



}
