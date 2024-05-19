using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCan : MonoBehaviour
{
    public bool inReach;
    public bool oilPickedUp;
    public GameObject oilCan;
    public AudioSource fillSound;

    public void Start()
    {
        inReach = false;
        oilPickedUp = false;
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
            oilPickedUp = true;
            oilCan.SetActive(false);
            fillSound.Play();
        }


    }
}
