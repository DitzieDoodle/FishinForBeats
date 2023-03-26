using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DigitalPenguin.Unity.Persistence;

public class ComboManager : MonoBehaviour
{
    public ComboLevel[] levels = new ComboLevel[12];

    public float soundTrackVolume = 0.8f;
    public int comboLevel = 0;
    public TMPro.TextMeshProUGUI comboLabel;
    public AudioSource missed;
    public Animator hudAnim;
    public GameObject player;

    private int comboStageSaved = 0;
    private int comboStage = 0;

    private void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        comboStageSaved = GetComponent<PlayerPrefInt>().Value;
    }
    public void OnBeat()
    {
        comboLevel++;
        comboLabel.SetText(comboLevel.ToString("D3"));
        UpdateMusic();

        UpdateComboPref();
    }

    private void UpdateComboPref()
    {
        if(comboLevel>=comboStageSaved)
        {
            GetComponent<PlayerPrefInt>().Save(comboLevel);
        }
    }

    public void BeatMissed()
    {
        comboLevel = 0;
        comboLabel.SetText(comboLevel.ToString("D3"));
        missed.Play();
        UpdateMusic();
    }

    void Update()
    {
        
    }

    void UpdateMusic()
    {
        this.player.GetComponent<Animator>().SetInteger("ComboBeats", this.comboLevel);
        bool trackOn = false;
        for (int i = levels.Length-1; i >= 0; i--)
        {
            if (!trackOn)
            {
                levels[i].audio.volume = 0f;
            }
            // Wenn die mindest-Beats der Combo-Stage Definition erreicht sind ...
            if (this.comboLevel >= levels[i].minBeats)
            {
                // ... und bereits ein anderer Track "aktiv" ist
                if (trackOn)
                {
                    // ... dann den hier muten
                    Debug.Log("Muting :" + levels[i].audio.name);
                    levels[i].audio.volume = 0f;
                }
                // ... und noch kein anderer Track "aktiv" ist ...
                else
                {
                    // ... dann diesen hier anschalten
                    Debug.Log("Volume up :" + levels[i].audio.name);
                    levels[i].audio.volume = soundTrackVolume;
                    trackOn = true;

                    if(i>this.comboStage)
                    {
                        hudAnim.SetTrigger("HUDCombo");
                    }

                    this.comboStage = i;
                }
            }
        }
    }
}

[Serializable]
public class ComboLevel
{
    public int minBeats = 0;
    public AudioSource audio;
}
