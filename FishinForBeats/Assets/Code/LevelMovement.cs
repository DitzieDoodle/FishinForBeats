using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class LevelMovement : MonoBehaviour

{
    public float movespeed=1;
    void Update()
    {
        LeanTween.moveX(this.gameObject,this.transform.position.x-movespeed, 1);
    }

}
