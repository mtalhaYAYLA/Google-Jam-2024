using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject woodGate;
    public bool pickedUpKey;
    
    
    private Animator anim;
    public GameObject keyDoor;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            
            anim.Play("Open");
            Destroy(keyDoor);
            inReach = false;
            pickedUpKey = true;
        }
    }
}
