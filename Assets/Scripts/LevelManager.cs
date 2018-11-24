using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance;

    public float speedDown = 2;
    
    public float timeGoing = 0;
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
    
 //   public int scoreGoal = 100;
    public bool goalReached = false;
    public bool gameLost = false;

    private void Awake()
    {
        Cursor.visible = false;

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

        //goal.text = "Find the correct battery";
        Instance = this;
    }

    public void TogglePause()
    { 
        paused = !paused;
        Cursor.visible = paused;
        PauseScreen.SetActive(paused);
        Time.timeScale = paused? 0 : 1;
    }

private void Update()
    {
        if (goalReached)
        {
            WinLevel();
            return;
        } else if (gameLost)
        {
            LostLevel();
            return;
        }

        timeGoing += Time.deltaTime;
        time.text = "" + (int)(timeGoing);

        speedDown += Time.deltaTime * 0.5f;
    }
    
    public void WinLevel()
    {
        // Load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LostLevel()
    {
        Restart();
    }

    public void ShowMenu()
    {
        PauseScreen.SetActive(true);
    }

    public void Restart()
    {
        int score = (int)timeGoing;
        PlayerPrefs.SetInt("bvb" + "_lastscore", score);

        if (score > PlayerPrefs.GetInt("bvb" + "_bestscore", 0))
        {
            PlayerPrefs.SetInt("bvb" + "_bestscore", score);
        }

        // Reload level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
