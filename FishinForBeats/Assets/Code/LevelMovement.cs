using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class LevelMovement : MonoBehaviour

{
    public float movespeed=1;
    void Update()
    {
        //    LeanTween.moveX(this.gameObject,this.transform.position.x-movespeed, 1);

        // this.transform.Translate(new Vector2(0, -1 * movespeed)*Time.deltaTime);

        this.transform.Translate(new Vector2(-1 * movespeed,0) * Time.deltaTime);
    }

}
