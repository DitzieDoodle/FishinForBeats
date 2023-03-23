using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboBreakerWall : MonoBehaviour
{
    private ComboManager comboManager;

    private void Awake()
    {
        this.comboManager = GameObject.FindGameObjectWithTag("ComboManager").GetComponent<ComboManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Beat"))
        {
            this.comboManager.BeatMissed();

        }
    }
}
