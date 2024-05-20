using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public Animator woodGate;
    public bool pickedUpKey;
    public bool inReach;
    public GameObject key;

    public void Start()
    {
        inReach = false;
        pickedUpKey = false;
        
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
            pickedUpKey = true;
            Destroy(key);
            woodGate.Play("Open");
        }


    }
}
