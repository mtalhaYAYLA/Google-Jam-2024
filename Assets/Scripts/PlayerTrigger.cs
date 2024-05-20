using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject monster;
    public Transform monsterStartPoint;
    public GameObject triggerPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Burada Canavar Serbest Kaldý UI Açýlacak ve belli bir süre sonra kapatýlacak
            Debug.Log("Player trigger entered. Resetting monster position.");
            monster.transform.position = monsterStartPoint.position;
            monster.SetActive(true); // Canavarý aktif hale getiriyoruz
            Destroy(triggerPlayer);

        }
    }
}
