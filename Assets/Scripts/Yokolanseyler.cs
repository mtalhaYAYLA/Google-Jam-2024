using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Yokolanseyler : MonoBehaviour
{
    public bool inReach = false;
    public GameObject uiTextObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            uiTextObject.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
            uiTextObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        inReach = false;
        uiTextObject.SetActive(false);
    }


}
