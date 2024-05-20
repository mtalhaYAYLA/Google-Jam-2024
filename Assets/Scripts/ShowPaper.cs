using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPaper : MonoBehaviour
{
    public GameObject paperObject;
    


    public bool inReach;


    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            paperObject.SetActive(true);


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            paperObject.SetActive(false);

        }
    }




   
}
