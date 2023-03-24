using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BeatsManager : MonoBehaviour
{
    public ComboManager comboManager;
    public int beats=0;
    public GameObject player;
    public TMPro.TextMeshProUGUI beatsLabel;
    public Animator hudAnim;

    private void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnBeat()
    {
        beats++;
        hudAnim.SetTrigger("HUDBeat");
        beatsLabel.SetText(beats.ToString("D3"));
        this.comboManager.OnBeat();
    }
}