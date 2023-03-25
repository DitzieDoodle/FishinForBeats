using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    public void GoToTS()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
