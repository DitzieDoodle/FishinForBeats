using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.L))
            {
            SceneManager.LoadScene("BeatLoser");
            }

        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("BeatKing");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
   
}
