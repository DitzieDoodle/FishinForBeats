    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int health = 3;
    private ComboManager comboManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            this.comboManager.BeatMissed();

        }
    }

    private void Awake()
    {
        this.comboManager = GameObject.FindGameObjectWithTag("ComboManager").GetComponent<ComboManager>();
    }
}
