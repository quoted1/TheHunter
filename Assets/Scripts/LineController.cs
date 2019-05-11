using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {

    public GameObject stringTop;
    public GameObject stringBottom;

    private LineRenderer stringTopLR;
    private LineRenderer stringBottomLR;

    private void Start()
    {
        stringTopLR = stringTop.GetComponent<LineRenderer>();
        stringBottomLR = stringBottom.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        stringTopLR.SetPosition(0, stringTop.transform.position);
        stringTopLR.SetPosition(1, this.transform.position);

        stringBottomLR.SetPosition(0, stringBottom.transform.position);
        stringBottomLR.SetPosition(1, this.transform.position);



    }

}
