using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastController : MonoBehaviour
{
    
    //all public for now
    public GameObject lastMovementTarget;
    public bool targetNull;
    public GameObject[] movementTargets;
    public float mTDistance;
    public RaycastHit hit;
    public GameObject hitTextHolder;
    private bool LoadingInitiated;

    //texture for point location
    public GameObject pointDot;
    private GameObject pointDotObj;

    private int lMask;

    // Use this for initialization
    void Start()
    {
        movementTargets = GameObject.FindGameObjectsWithTag("MovementTarget");
        LoadingInitiated = false;
        pointDot.SetActive(false);

        lMask = 1 << 2;
        lMask = ~lMask;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        inputDetection();
    }

    void inputDetection()
    {
        if (OVRInput.Get(OVRInput.Button.One)) //Starts raycasting functionality
        {
            buttonAHeld();
        }

        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            buttonAUp();
        }
    }

    void buttonAHeld()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, lMask);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

        if (OVRInput.Get(OVRInput.Button.One))
        {
            pointDot.SetActive(true); //shows the point orb
            pointDot.transform.position = hit.point; //sets the position of the point orb
        }

        //the following code for showing the waypoints will be deleted eventually 
        foreach (GameObject MT in movementTargets) // this code is no longer needed due to not needing to hide the waypoints
        {
            mTDistance = Vector3.Distance(this.gameObject.transform.position, MT.transform.position);
            if (mTDistance <= 20.0f && MT.GetComponent<CurrentMT>().currentMT == false)
            {
                MT.SetActive(true);
            }
            else
            {
                MT.SetActive(false);
            }
        }

       

        /*
        //add in menu scene ui controls
        if(hit.collider.gameObject.name == "PlayGameCube")
        {
            hit.collider.gameObject.GetComponentInParent<Text>().color = Color.green;
        }
        if (hit.collider.gameObject.name == "OverViewCube")
        {
            hit.collider.gameObject.GetComponentInParent<Text>().color = Color.green;
        }
        if (hit.collider.gameObject.name == "ExitGameCube")
        {
            hit.collider.gameObject.GetComponentInParent<Text>().color = Color.red;
        }
        */
    }

    void buttonAUp()
    {
        if (hit.collider.tag == "MovementTarget")
        {
            GetComponentInParent<MoveTowards>().targetObj = hit.transform;
            //Debug.Log("Targetset");

            this.gameObject.GetComponentInParent<MoveTowards>().moving = true;

            //resettng the currentMT
            foreach (GameObject MT in movementTargets)
            {
                MT.GetComponent<CurrentMT>().currentMT = false;
            }
            hit.transform.gameObject.GetComponent<CurrentMT>().currentMT = true;
            hit.transform.gameObject.SetActive(false);
        }

        pointDot.SetActive(false); // hides the point orb
    }
}
