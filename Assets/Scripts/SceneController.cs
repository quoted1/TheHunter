using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public bool LoadingInitiated, playGame, OverView;
    public GameObject gameController, Menu01, showMenuShield;
    public Text descriptionTxt, overControlTxt;

    private void Start()
    {
        OverView = true;
        showMenuShield.SetActive(false);
    }

    public void HideMenuPress()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(HideMenu());
        }
    }
    IEnumerator HideMenu() //possibly obselete
    {
        Menu01.SetActive(false);
        showMenuShield.SetActive(true);
        yield return false;
    }

    public void ReturnMenuPress()
    {
        StartCoroutine(ReturnMenu());
    }
    public IEnumerator ReturnMenu() //possibly obselete
    {
        Menu01.SetActive(true);
        showMenuShield.SetActive(false);
        StartCoroutine(gameController.GetComponent<ScoreController>().ResetPlayerPosition());
        yield return false;
    }

    public void OverControlPress()
    {
        if (OverView == true)
        {
            StartCoroutine(ShowControls());
            OverView = false;
        }
        else
        {
            StartCoroutine(ShowOverView());
            OverView = true;
        }
    }
    IEnumerator ShowControls()
    {
        overControlTxt.text = "OverView";
        descriptionTxt.text = "Controls - Right Touch Controller\n\n" +
                                "A - Movement Orb\n" +
                                "(You can move to any Totem Pole)\n\n" +
                                "Front Trigger Held - Spawn / Hold Arrow\n" +
                                "(Interacts like a Bow and Arrow)\n\n" +
                                "Use the bow to interact with Objects in the world and the movement orb to move to around";
        yield return false;

    }
    IEnumerator ShowOverView()
    {
        overControlTxt.text = "Controls";
        descriptionTxt.text = "See how fast you can shoot all the targets\n\n" +
                                "Enter the course behind you and start the timer";
                yield return false;
    }
   }
