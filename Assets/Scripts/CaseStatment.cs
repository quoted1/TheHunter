using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseStatment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject X in this.gameObject.transform)
        {
            string Xname = X.name;

            switch (Xname)
            {
                case "Red":
                    //some code
                    break;
                case "Yellow":
                    //some code
                    break;
                case "Green":
                    //some code
                    break;
                default:
                    //some code
                    break;
            }
        }
    }

    
}
