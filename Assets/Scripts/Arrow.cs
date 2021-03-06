﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    #region Variables
    public float DropArrow = 0.35f;

    private Rigidbody rb;
    public float arrowSpeed;
    public float arrowPower;
    private bool colliding;
    private GameObject collidedGameObject;

    public AudioSource arrowHit;
    #endregion

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(11, 18); //ignores collissions between the player and arrows
        
    }

    private void Update()
    {
        if (rb != null)
        {
            arrowSpeed = rb.velocity.magnitude;
        }

        if (this.name == "Arrow" && rb.velocity.magnitude >= 5)
        {
            this.transform.forward = rb.velocity;
        }

        if (this.name == "nockedArrow")
        {
            this.transform.localPosition = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
    //moved the trigger to the hand rather than on the arrow (HandCollisionController)
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bow" && this.tag == "Arrow")
        {
            Debug.Log("Arrow and bow connected");
            this.gameObject.tag = "NockedArrow";
            ArrowManager.Instance.AttachBowToArrow();
        }
    }
    */

    void OnCollisionEnter(Collision colObj)
    {
        colliding = true;

        if (this.name == "Arrow")
        {
            arrowHit.Play();
        }

        collidedGameObject = colObj.gameObject;
        if (arrowPower >= 15 && this.gameObject.name != "nockedArrow")
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Debug.Log("arrow stuck");
            this.transform.parent = colObj.transform;
            Destroy(GetComponent<Rigidbody>());
            arrowPower = 0;
        }

        if (collidedGameObject.tag == "MenuObj")
        {
            //Debug.Log(collidedGameObject.name);
            MenuInteractions();
        }

        if (collidedGameObject.tag == "ScoreTarget")
        {
            //Debug.Log(collidedGameObject.name);
            ScoreInteractions();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
        if (this.gameObject.name == "nockedArrow")
        {
            this.transform.localEulerAngles = new Vector3(0, 0, 0) ;
        }
    }

    void MenuInteractions()
    {
        string HitName = collidedGameObject.name;

        switch (HitName)
        {
            case "HideMenu":
                //some code
                //Debug.Log("game started");
                GetComponentInParent<SceneController>().HideMenuPress();
                break;
            case "OverControl":
                //some code
                //Debug.Log("Overview hit");
                GetComponentInParent<SceneController>().OverControlPress();
                break;
            case "ExitGame":
                //some code
                Application.Quit();
                break;
            case "ShowMenu":
                //some code
                GetComponentInParent<SceneController>().ReturnMenuPress();
                break;
            default:
                //some code
                Debug.Log("Default menu interaction");
                break;
        }
    }

    void ScoreInteractions()
    {   //the names of the collidedgameobject needs to be the same as the name of the object in scene
        string HitName = collidedGameObject.name;

        switch (HitName)
        {
            case "Red":
                //some code
                Debug.Log("Get Good - 5 Points");
                GetComponentInParent<TargetController>().OuterRingHit(collidedGameObject);
                break;
            case "Yellow":
                //some code
                Debug.Log("Close - 10 Points");
                GetComponentInParent<TargetController>().MiddleRingHit(collidedGameObject);
                break;
            case "Green":
                //some code
                Debug.Log("Bulls-eye - 20 points");
                GetComponentInParent<TargetController>().CenterRingHit(collidedGameObject);
                break;
            case "GameTarget":
                //some code
                Debug.Log("Target hit");
                GetComponentInParent<GameTargetController>().TargetHit(collidedGameObject);
                break;
            case "ResetTimer":
                //some code
                GetComponentInParent<TargetController>().ResetTimer();
                break;
            case "StartTimer":
                //some code
                GetComponentInParent<TargetController>().StartTimer();
                break;
            case "ReturnMenu":
                //some code
                GetComponentInParent<SceneControllerLink>().ReturnMenuLink();
                break;
            default:
                //some code
                Debug.Log("ScoreInteractions called for no reason");
                break;
        }
    }
}
