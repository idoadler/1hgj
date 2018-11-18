using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableLetter : MonoBehaviour
{
    public char current;
    public int score = 10;
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //LevelManager.Instance.TargetLetter;        
        Invoke("DestroyMe", 2 + Random.value * 3);
    }

    private void DestroyMe()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = new Color(1, 1, 1, 0.5f);
        Invoke("FinalDestroy", 1);
    }

    private void FinalDestroy()
    {
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        if (LevelManager.Instance.paused)
            return;

        if (current == LevelManager.Instance.TargetLetter)
        {
            LevelManager.Instance.UpdateScore(score);
        }
        else
        {
            LevelManager.Instance.LostLevel();
        }
        Destroy(gameObject);
    }
}
