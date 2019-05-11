using UnityEngine;

public class ArrowManager : MonoBehaviour {

    #region
    public GameObject currentArrow;
    private GameObject droppedArrow;
    private GameObject nockedArrow;
    private bool holdingArrow = false;
    public GameObject arrowPrefab;
    public GameObject bow;
    public GameObject arrowPointPos;
    private Transform bowStart;

    public float SpawnArrow = 0.55f;
    public float DropArrow = 0.35f;
    private float stringPower;
    public float totalPower;
    private bool arrowNocked;

    public Transform leftHand;
    public Transform rightHand;
    public float handDist;

    public static ArrowManager Instance;

    public GameObject stringAttachPoint;
    public Vector3 bowDirection;

    public AudioSource bowNock;
    public AudioSource bowLoose;
    #endregion

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    void Start() {
        currentArrow = null;
        holdingArrow = false;
        arrowNocked = false;
        bowStart = bow.transform;
        stringPower = 45f;
    }

    void Update() {
        GrabArrow();
        FireArrow();
        handDist = Vector3.Distance(leftHand.position, rightHand.position);

        if (arrowNocked == true)
        {
            stringAttachPoint.transform.LookAt(arrowPointPos.transform);
            nockedArrow.transform.localEulerAngles = Vector3.zero;
        }        
    }

    private void GrabArrow()
    {
        if (currentArrow == null && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= SpawnArrow && holdingArrow == false)
        {
            //Debug.Log("grabbing arrow");
            currentArrow = Instantiate(arrowPrefab);
            currentArrow.transform.parent = rightHand;
            currentArrow.transform.localPosition = new Vector3(0, 0, 0);
            currentArrow.transform.localEulerAngles = new Vector3(0, 0, 0);
            currentArrow.name = "CurrentArrow";
            holdingArrow = true;
            //Debug.Log("holding Arrow");
            //use above to alter the location of the arrow if its centered to the touch controller
            rightHand.gameObject.GetComponent<HandCollisionController>().holdingArrow = true;
        }
        else if (holdingArrow == true && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) <= DropArrow)
        {
            //Debug.Log("Dropping Arrow");
            //currentArrow.AddComponent<Rigidbody>();
            currentArrow.GetComponent<Rigidbody>().useGravity = true;
            currentArrow.transform.parent = null;
            droppedArrow = currentArrow;
            currentArrow = null;
            holdingArrow = false;
            droppedArrow.name = "DroppedArrow";
            Destroy(droppedArrow, 5);

            rightHand.gameObject.GetComponent<HandCollisionController>().holdingArrow = false;
        }
    }

    public void AttachBowToArrow()
    {
        currentArrow.transform.SetParent(stringAttachPoint.transform);
        currentArrow.transform.localPosition = new Vector3(0, 0, 0);
        currentArrow.transform.localEulerAngles = Vector3.zero;
        nockedArrow = currentArrow;
        nockedArrow.name = "nockedArrow";
        nockedArrow.tag = "NockedArrow";
        arrowNocked = true;
        bowNock.Play();
        nockedArrow.transform.forward = stringAttachPoint.transform.forward;
        stringAttachPoint.transform.SetParent(rightHand.transform);
        stringAttachPoint.transform.localPosition = new Vector3(0, 0, 0);

    }

    void FireArrow()
    {
        totalPower = (Vector3.Distance(leftHand.position, rightHand.position) * stringPower);

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) <= DropArrow && nockedArrow.tag == "NockedArrow")
        {
            nockedArrow.transform.parent = null;
            nockedArrow.GetComponent<Rigidbody>().useGravity = true;
            nockedArrow.GetComponent<Rigidbody>().AddForce(nockedArrow.transform.forward * totalPower, ForceMode.Impulse); //alter the direction of the force depending on the gameobject when you get the new models for the bow and arrows
            currentArrow = null;
            nockedArrow.GetComponent<Arrow>().arrowPower = totalPower;
            nockedArrow.name = "Arrow";
            Destroy(nockedArrow, 5);
            nockedArrow = null;

            holdingArrow = false;
            arrowNocked = false;
            resetBowTrans();
            bowLoose.Play();
        }
    }

    void resetBowTrans()
    {
        stringAttachPoint.transform.SetParent(bow.transform);
        stringAttachPoint.transform.localPosition = new Vector3(0, 0, -0.1785f);
        //Debug.Log("bow reset");
    }
}
