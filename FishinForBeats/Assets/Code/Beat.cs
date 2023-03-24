using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public BeatsManager beatsManager;
    public AudioSource blubb;
    public Animator playerAnim;
    public Animator hudAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blubb.Play();
            beatsManager.OnBeat();
            playerAnim.SetTrigger("Beat");
            hudAnim.SetTrigger("HUDBeat");
            Destroy(this.gameObject);
        }
    }
}
