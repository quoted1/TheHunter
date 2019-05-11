using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    bool LoadingInitiated;
    //GameObject[] PauseMenuObjects;
    public AudioSource Menuforward;
    public AudioSource Menubackward;

    public GameObject menu01;
    public GameObject menu02;

    void Awake()
    {
        LoadingInitiated = false;
    }

    private void Start()
    {
        menu02.SetActive(false);
    }


    public void PlayGamePress()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(PlayGame());
            LoadingInitiated = true;
        }
    }
    IEnumerator PlayGame()
    {
        //Time.timeScale = 1;
        //Menuforward.Play();
        //yield return new WaitForSeconds(Menuforward.clip.length);
        SceneManager.LoadScene(1);
        //Debug.Log("Game started");
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
