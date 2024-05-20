using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject monster;
    public Transform monsterStartPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player trigger entered. Resetting monster position.");
            monster.transform.position = monsterStartPoint.position;
            monster.SetActive(true); // Canavarý aktif hale getiriyoruz

            // Debug log ekle
            Debug.Log($"Monster new position: {monster.transform.position}");
        }
    }
}
