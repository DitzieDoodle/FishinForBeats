    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int health = 3;
    private ComboManager comboManager;
    public Animator playerAnim;
    public Animator hudAnim;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public AudioSource ouch;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            playerAnim.SetTrigger("Ouch");
            ouch.Play();
            hudAnim.SetTrigger("HUDHeart");
            this.comboManager.BeatMissed();

        }
    }

    private void Awake()
    {
        this.comboManager = GameObject.FindGameObjectWithTag("ComboManager").GetComponent<ComboManager>();
    }

    private void Update()
    {
        if(health <=2)
        {
            heart1.SetActive(true);
        }

        if (health <= 1)
        {
            heart2.SetActive(true);
        }

        if (health<=0)
        {
            heart3.SetActive(true);
        }
    }
    
}
