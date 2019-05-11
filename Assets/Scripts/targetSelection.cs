using UnityEngine;
using UnityEngine.UI;

public class targetSelection : MonoBehaviour {

    /*
     * this entire script needs a second pass to make it more efficient
     * there needs to be an input controller to start all the interations
     * at the moment the raycast is always going rather than it starting when the player presses the button
     */

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

    // Use this for initialization
    void Start () {
        movementTargets = GameObject.FindGameObjectsWithTag("Movementtarget");
        LoadingInitiated = false;
        pointDot.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if(hit.collider.tag == "Movementtarget" && (OVRInput.GetUp(OVRInput.Button.One)))
            {
                GetComponentInParent<MoveTowards>().targetObj = hit.transform;
                Debug.Log("Targetset");

                this.gameObject.GetComponentInParent<MoveTowards>().moving = true;

                //resettng the currentMT
                foreach (GameObject MT in movementTargets)
                {
                    //MT.SetActive(true);
                    MT.GetComponent<CurrentMT>().currentMT = false;
                }
                hit.transform.gameObject.GetComponent<CurrentMT>().currentMT = true;
                hit.transform.gameObject.SetActive(false);
            }

            if(hit.collider.tag == "Movementtarget")
            {
                lastMovementTarget = hit.transform.gameObject;
                if (GetComponent<Outline>() && OVRInput.GetDown(OVRInput.Button.One))
                {
                    //GetComponent<Outline>().OutlineWidth = 10f;
                }
                if (GetComponent<Outline>() && OVRInput.GetUp(OVRInput.Button.One))
                {
                    //GetComponent<Outline>().OutlineWidth = 0f;
                }

            }

            //menu contoller
            if(hit.collider.tag == "MenuObj")
            {
                if(hit.transform.name == "PlayGame")
                {
                    hitTextHolder = hit.transform.gameObject;
                    hit.transform.GetComponent<Text>().color = Color.red;
                    // add loading coroutine here for changing scene
                    
                    if (!LoadingInitiated)
                    {
                        //StartCoroutine(LevelLoad());
                        LoadingInitiated = true;
                    }
                }
                else
                {
                    hitTextHolder.transform.GetComponent<Text>().color = Color.black;
                }

                if (hit.transform.name == "OverView")
                {
                    hitTextHolder = hit.transform.gameObject;
                    hit.transform.GetComponent<Text>().color = Color.red;
                    // Change Canvas for overview information
                }
                else
                {
                    hitTextHolder.transform.GetComponent<Text>().color = Color.black;
                }
                if (hit.transform.name == "ExitGame")
                {
                    hitTextHolder = hit.transform.gameObject;
                    hit.transform.GetComponent<Text>().color = Color.red;
                    if(OVRInput.Get(OVRInput.Button.One))
                    {
                        Application.Quit();
                    }
                }
                else
                {
                    hitTextHolder.transform.GetComponent<Text>().color = Color.black;
                }
            }

            //user point location dot
            if (OVRInput.Get(OVRInput.Button.One))
            {
                pointDot.SetActive(true); //shows the reticle
                var heading = this.transform.position - hit.point; //gets the un-normalized direction vector
                var distance = heading.magnitude; //gets the distance 
                var direction = heading / distance; //gets the normalized direction
                pointDot.transform.position = hit.point; //sets the position of the plane
            }
            if (OVRInput.GetUp(OVRInput.Button.One))
            {
                pointDot.SetActive(false);
            }

        }//raycasting controller

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

    }//end of update

    /*
    IEnumerator LevelLoad()
    {
        yield return new WaitForSeconds(Menuforward.clip.length);
        SceneManager.LoadScene(1);
        Debug.Log("Game started");
    }
    */
}
