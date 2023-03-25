using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundInAnim : MonoBehaviour
{
    public AudioSource sound;

    public void PlaySound(AnimationEvent e)
    {
        sound.Play();
    }
}
