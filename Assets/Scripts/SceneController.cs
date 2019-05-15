using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    bool LoadingInitiated, playGame;
    //GameObject[] PauseMenuObjects;
    public AudioSource Menuforward, Menubackward;
    public GameObject menu01, menu02, enclosureObj, enclosureMoveToObj, enclosureReturnObj, moveObj, gameController;

    void Awake()
    {
        LoadingInitiated = false;
    }

    private void Start()
    {
        menu02.SetActive(false);
    }

    private void Update()
    {
        if (playGame == true && Vector3.Distance(enclosureObj.transform.position, moveObj.transform.position) > 0.1f)
        {
            enclosureObj.transform.position = Vector3.MoveTowards(enclosureObj.transform.position, enclosureMoveToObj.transform.position, 0.02f);
        }
        else if(playGame == false && Vector3.Distance(enclosureObj.transform.position, moveObj.transform.position) > 0.1f)
        {
            enclosureObj.transform.position = Vector3.MoveTowards(enclosureObj.transform.position, enclosureReturnObj.transform.position, 0.02f);
        }
    }


    public void PlayGamePress()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(PlayGame());
        }
    }
    IEnumerator PlayGame() //possibly obselete
    {
        playGame = true;
        moveObj = enclosureMoveToObj;
        yield return false;
    }

    public void ReturnMenuPress()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(ReturnMenu());
        }
    }
    public IEnumerator ReturnMenu() //possibly obselete
    {
        playGame = false;
        moveObj = enclosureReturnObj;
        StartCoroutine(gameController.GetComponent<ScoreController>().ResetPlayerPosition());
        yield return false;
    }

    public void OverViewPress()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(OverView());
        }
    }
    IEnumerator OverView()
    {
        //Time.timeScale = 1;
        //Menuforward.Play();
        //yield return new WaitForSeconds(Menuforward.clip.length);
        menu01.SetActive(false);
        menu02.SetActive(true);
        //Debug.Log("overview");
        yield return false;

    }

    public void BackPress()
    {
        Debug.Log("log");
        if (!LoadingInitiated)
        {
            //Debug.Log("log2");

            StartCoroutine(Back());
        }
    }
    IEnumerator Back()
    {
        //Menuforward.Play();
        //yield return new WaitForSeconds(Menuforward.clip.length);
        menu01.SetActive(true);
        menu02.SetActive(false);
        //Debug.Log("mainmenu");
        yield return false;
    }

    public void CloseGamePress()
    {
        Application.Quit();
    }
   }
