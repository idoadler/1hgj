﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance;
    
    public int target = 3;
    
    public float timeGoing = 30;
    public int nScore = 0;
    public Text score;
    public Text time;
    public Text timeTitle;
    public Text goal;
    
    public Text BestScore;
    public Text CurrentScore;


    public Text PlayAgain;
    public KeyCode Pause = KeyCode.Space;
    public GameObject PauseScreen;

    public bool paused = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("bvb" + "_lastscore"))
        {            
            CurrentScore.text = "Score: " + PlayerPrefs.GetInt("bvb" + "_lastscore", 0);
            if (PlayerPrefs.GetInt("bvb" + "_bestscore") > PlayerPrefs.GetInt("bvb" + "_lastscore", 0))
            {
                BestScore.text = "Best Score: " + PlayerPrefs.GetInt("bvb" + "_bestscore");
            }
            else
            {
                BestScore.text = "New Record!";
            }
            TogglePause();
        }
        else
        {
            PauseScreen.SetActive(false);
            BestScore.text = "";
            CurrentScore.text = "";
        }

        Instance = this;
        
        time.text = target.ToString();
    }
    //
    // private void Update()
    // {
    //     timeGoing += Time.deltaTime;
    //     // if(timeGoing <0)
    //     //     LostLevel();
    //     // else
    //     {
    //         time.text = timeGoing.ToString();
    //     }
    // }

    public void TogglePause()
    {
        PauseScreen.SetActive(false);

        paused = !paused;
        PauseScreen.SetActive(paused);
        Time.timeScale = paused? 0 : 1;
    }
    
    public void WinLevel()
    {
        //Invoke("GoNext", 1);
        GoNext();
    }

    private void GoNext()
    {
        // Load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LostLevel()
    {
        Restart();
       // SceneManager.LoadScene(BackButton.MAIN_SCENE);
    }

    public void ShowMenu()
    {
        PauseScreen.SetActive(true);
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("bvb" + "_lastscore", nScore);

        if (nScore > PlayerPrefs.GetInt("bvb" + "_bestscore", 0))
        {
            PlayerPrefs.SetInt("bvb" + "_bestscore", nScore);
        }

        // Reload level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int i)
    {
        nScore++;
        score.text = nScore.ToString();
    }

    public void Hit(GameObject duck)
    {
        target--;
        time.text = target.ToString();
        if (target < 0)
            LostLevel();
        Destroy(duck);
    }
}
