using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFuel : MonoBehaviour
{

    // Update is called once per frame
    public Light pointLight;
    private static float fuel = 7f;
    private float decreaseRate = 0.08f; // Her saniyede range de�erini azaltmak i�in kullan�lacak miktar
    private static bool onHand = false;
    void Update()
    {
        if (onHand) 
        {
            fuel = fuel - decreaseRate * Time.deltaTime;
            pointLight.range = Mathf.Max(fuel, 0); // range de�eri 0'dan k���k olamaz
            
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
    public static void setFuelAmount(float amount)
    {
        fuel = fuel + amount;
    }
    public static float getFuelAmount()
    {
        return fuel;
    }
}
