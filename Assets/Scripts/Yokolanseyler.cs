using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yokolanseyler : MonoBehaviour
{
    public bool inReach = false;
    public GameObject warningText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            warningText.SetActive(true);


        }


    }

    private void Update()
    {
        
    }
}
