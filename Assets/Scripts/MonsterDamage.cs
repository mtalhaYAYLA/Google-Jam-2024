using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        // Oyun durdurma iþlemleri burada yapýlýr
        Debug.Log("Monster touched the player! Game Over.");
        // StartCoroutine(StopGame());
    }
}
