using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFuel : MonoBehaviour
{

    // Update is called once per frame
    public Light pointLight;
    public float fuel = 7f;
    private float decreaseRate = 0.05f; // Her saniyede range deðerini azaltmak için kullanýlacak miktar
    private static bool onHand = false;
    void Update()
    {
        if (onHand) 
        {
            fuel = fuel - decreaseRate * Time.deltaTime;
            pointLight.range = Mathf.Max(fuel, 0); // range deðeri 0'dan küçük olamaz
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oil"))
        {
            fuel++;
        }
    }

    public bool getOnHand()
    {
        return onHand;
    }
    public static void setOnHand(bool v)
    {
        onHand = v;
    }
}
