using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 90f;
    public TMPro.TextMeshProUGUI timerLabel;
    public Animator timerAnim;
    private void Update()
    {
        timer = Mathf.Max(0, timer - Time.deltaTime);
        timerLabel.SetText(timer.ToString("0"));

        if(timer <= 0f)

        {   timerAnim.SetTrigger("Timer");
        }
    }
}
