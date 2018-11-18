using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTouchME : MonoBehaviour
{
    public Sprite broken;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Floor")
        {
            GetComponent<SpriteRenderer>().sprite = broken;
            GetComponent<Collider2D>().enabled = false;
            LevelManager.Instance.gameLost = true;
        }
    }
}
