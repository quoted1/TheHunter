using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public int Score;
    public Text scoreText;

    private bool startTimer;
    private float timer, seconds, minutes;
    public Text timerText;
    private string timerString;
    public GameObject playerObj, resetPositionObj;


    private void Awake()
    {
        startTimer = false;
        timer = 0f;
        
        UpdateTimer();
    }

    public void Update()
    {
        if (startTimer == true)
        {
            timer += Time.deltaTime;
            UpdateTimer();
        }
    }
    private void UpdateTimer()
    {
        seconds = timer % 60;
        minutes = timer / 60;
        timerString = string.Format("{00:00}:{01:00}", minutes, seconds);
        timerText.text = "Time:\n" + timerString;
    }

    public void ScoreUp(int score)
    {
        Score += score;
        //Debug.Log("Score is: " + Score);
        scoreText.text = "Score \n" + Score;
    }

    public void StartTimer()
    {
        timer = 0f;
        startTimer = true;
    }

    public void StopTimer()
    {
        startTimer = false;
    }

    public void RestartTimer()
    {
        startTimer = false;
        timer = 0f;
    }
    public void EndGame()
    {
        timerString = string.Format("{00:00}:{01:00}", minutes, seconds);
        timerText.text = "Well Done\nTime:\n" + timerString;
        StartCoroutine(ResetPlayerPosition());
    }

    private IEnumerator ResetPlayerPosition()
    {
        playerObj.transform.position = resetPositionObj.transform.position;
        yield return new WaitForSeconds(1f);
    }
}
