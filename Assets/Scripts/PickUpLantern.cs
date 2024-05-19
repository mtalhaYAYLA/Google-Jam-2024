using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLantern : MonoBehaviour
{
    public GameObject pickableLantern;
    public bool lanternPickedUp;
    public bool inReach;
    public GameObject playerLantern;

    public void Start()
    {
        inReach = false;
        lanternPickedUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
    
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inReach)
        {
            lanternPickedUp = true;
            pickableLantern.SetActive(false);
            playerLantern.SetActive(true);
        }


    }

}
