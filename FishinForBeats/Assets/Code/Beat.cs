using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public BeatsManager beatsManager;
    public AudioSource blubb;
    public Animator playerAnim;
    //public Animator hudAnim;
    public ParticleSystem pop;
    public SpriteRenderer render;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blubb.Play();
            beatsManager.OnBeat();
            pop.Play();
            playerAnim.SetTrigger("Beat");
            //  hudAnim.SetTrigger("HUDBeat");
           // render.enabled = false;
            Destroy(this.gameObject);
            
        }
    }
}
