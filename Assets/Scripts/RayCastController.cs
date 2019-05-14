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
    private bool pointDotShown;

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
            pointDotShown = true;

        }

        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            buttonAUp();
            pointDotShown = false;
        }
    }

    void buttonAHeld()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, lMask);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

        pointDot.SetActive(true); //shows the point orb
        pointDot.transform.position = hit.point; //sets the position of the point orb

        
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
                MT.transform.gameObject.SetActive(true);

            }
            hit.transform.gameObject.GetComponent<CurrentMT>().currentMT = true;
            hit.transform.gameObject.SetActive(false);
        }

        StartCoroutine(HidePointOrb()); // hides the point orb
    }

    private IEnumerator HidePointOrb()
    {
        yield return new WaitWhile(() => pointDotShown);
        pointDot.SetActive(false);
    }
}
