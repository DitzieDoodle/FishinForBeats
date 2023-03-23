using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public BeatsManager beatsManager;
    public AudioSource blubb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blubb.Play();
            beatsManager.OnBeat();
            Destroy(this.gameObject);
        }
    }
}
