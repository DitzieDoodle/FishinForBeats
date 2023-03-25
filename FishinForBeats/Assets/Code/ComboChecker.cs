using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComboChecker : MonoBehaviour
{
    public ComboManager comboManager;
    private int combo;

    private void Awake()
    {
        this.comboManager = GameObject.FindGameObjectWithTag("ComboManager").GetComponent<ComboManager>();
    }

    private void Update()
    {
        this.combo = this.comboManager.comboLevel;
    }

    public void ComboCheck(AnimationEvent e)
    {
        if (combo <= 5)
        {
            SceneManager.LoadScene("BeatLoser");
        }

        else
        {
            SceneManager.LoadScene("BeatKing");
        }

    }

}
