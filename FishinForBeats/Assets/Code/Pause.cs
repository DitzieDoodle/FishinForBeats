using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool gamePaused = false;
    public Animator anim;
    public GameObject panel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            PauseGame();
            }
        }
    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void Continue()
    {
        if (gamePaused)
        {
            // anim.SetTrigger("Resume");
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }



}
