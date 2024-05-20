using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MonsterAgent : Agent
{
    public Transform playerTransform;
    private Rigidbody monsterRigidbody;

    public override void Initialize()
    {
        monsterRigidbody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        // Ajan ve oyuncunun pozisyonlarýný sýfýrla
        // transform.position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        // playerTransform.position = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f)); // Oyuncunun Y pozisyonunu 1 yap
        monsterRigidbody.velocity = Vector3.zero;
        monsterRigidbody.angularVelocity = Vector3.zero;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Monster'ýn pozisyonunu ekle
        sensor.AddObservation(transform.position);

        // Oyuncunun pozisyonunu ekle
        sensor.AddObservation(playerTransform.position);

        // Monster'ýn hýzýný ekle
        sensor.AddObservation(monsterRigidbody.velocity);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Sürekli aksiyonlarý al
        float moveX = actionBuffers.ContinuousActions[0];
        float moveZ = actionBuffers.ContinuousActions[1];

        // Hareket vektörü oluþtur
        Vector3 move = new Vector3(moveX, 0, moveZ);

        // Rigidbody'ye kuvvet uygula
        monsterRigidbody.AddForce(move * 10f);

        // Oyuncuya olan mesafeyi hesapla
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Mesafeyi yazdýr
        Debug.Log($"Mesafe: {distanceToPlayer}");


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndGame();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Horizontal");
        continuousActions[1] = Input.GetAxis("Vertical");
    }

    private void EndGame()
    {
        // Oyun durdurma iþlemleri burada yapýlýr
        Debug.Log("Monster touched the player! Game Over.");
        // StartCoroutine(StopGame());
    }

    private IEnumerator StopGame()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0; // Oyunu durdur
    }
}

