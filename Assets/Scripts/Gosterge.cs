using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gosterge : MonoBehaviour
{
    public TextMeshProUGUI sayac;
    void Update()
    {
        sayac.text = LanternFuel.getFuelAmount().ToString("F2");
    }
    
}
