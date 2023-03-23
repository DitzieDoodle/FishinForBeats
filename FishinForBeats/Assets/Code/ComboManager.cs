using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboManager : MonoBehaviour
{
    public ComboLevel[] levels = new ComboLevel[12];

    public float soundTrackVolume = 0.8f;
    public int comboLevel = 0;
    public TMPro.TextMeshProUGUI comboLabel;
    public AudioSource missed;

    public void OnBeat()
    {
        comboLevel++;
        comboLabel.SetText(comboLevel.ToString("D3"));
        UpdateMusic();
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
