using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableLetter : MonoBehaviour
{
    public bool correct;
    public int score = 10;

    void OnMouseDown()
    {
        if (LevelManager.Instance.paused)
            return;

        if (correct)
        {
            LevelManager.Instance.UpdateScore(score);
            LevelManager.Instance.Next();
        }
        else
        {
            LevelManager.Instance.LostLevel();
        }
    }
}
