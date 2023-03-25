using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public GameObject spawnerTimer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            {
            Debug.Log("Collision w Player");
            spawnerTimer.GetComponent<UniTimer>().StartTimer();




        }
    }
}
