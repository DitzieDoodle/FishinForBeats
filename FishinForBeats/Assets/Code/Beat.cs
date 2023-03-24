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
    public CircleCollider2D col;

    private void Awake()
    {
        this.beatsManager = GameObject.FindGameObjectWithTag("BeatsManager").GetComponent<BeatsManager>();
        this.playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        this.blubb = GameObject.FindGameObjectWithTag("Blubb").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            blubb.Play();
            beatsManager.OnBeat();
            pop.Play();
            playerAnim.SetTrigger("Beat");
            //  hudAnim.SetTrigger("HUDBeat");
            render.enabled = false;
            col.enabled = false;
            Destroy(this.gameObject);
            
        }
    }
}
