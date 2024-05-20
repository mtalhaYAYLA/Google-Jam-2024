using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //Game Over Sahnesi Açýlacak
        //Debug.Log("Monster touched the player! Game Over.");
        SceneManager.LoadScene("GameOver");
    }
}
