using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public int Score;
    public Text scoreText; 

    public void ScoreUp(int score)
    {
        Score += score;
        //Debug.Log("Score is: " + Score);
        scoreText.text = "Score \n" + Score;
    }
}
