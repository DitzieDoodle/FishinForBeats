using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerPos { TOP, MID, BOT }

    public Transform top;
    public Transform mid;
    public Transform bot;

    public float moveDuration = 1f;

    public PlayerPos position = PlayerPos.MID;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("UP!");
            switch(this.position)
            {
                case PlayerPos.MID:
                    LeanTween.moveY(this.gameObject, top.position.y, moveDuration);
                    this.position = PlayerPos.TOP;
                    break;
                case PlayerPos.BOT:
                    LeanTween.moveY(this.gameObject, mid.position.y, moveDuration);
                    this.position = PlayerPos.MID;
                    break;
                default: break;
            }
        } 
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("DOWN!");
            switch (this.position)
            {
                case PlayerPos.MID:
                    LeanTween.moveY(this.gameObject, bot.position.y, moveDuration);
                    this.position = PlayerPos.BOT;
                    break;
                case PlayerPos.TOP:
                    LeanTween.moveY(this.gameObject, mid.position.y, moveDuration);
                    this.position = PlayerPos.MID;
                    break;
                default: break;
            }
        }
    }

}
