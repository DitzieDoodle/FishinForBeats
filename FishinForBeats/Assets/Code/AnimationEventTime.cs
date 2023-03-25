using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTime : MonoBehaviour
{

     public void ResumeGame(AnimationEvent e)
        {
            Time.timeScale = 1;
        }

    public void StopGame(AnimationEvent e)
    {
        Time.timeScale = 0;
    }
}
