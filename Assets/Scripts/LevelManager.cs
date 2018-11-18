using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance;

    public Text score;
    public Text time;
    public Text goal;

    public Text BestScore;
    public Text CurrentScore;
    public Text PlayAgain;
    public KeyCode Pause = KeyCode.Space;
    public GameObject PauseScreen;

    public bool paused = false;

    public int timeLimit = 60;
 //   public int scoreGoal = 100;
    public bool goalReached = false;
    public bool gameLost = false;

    private int scoreCount;
    private float timeCount;
    public char[] letterOptions;
    public char TargetLetter;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_bestscore"))
        {
            BestScore.text = "Best Score:" + PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_bestscore");
            CurrentScore.text = "Your Score:" + PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_lastscore", 0);
            TogglePause();
        }
        else
        {
            PauseScreen.SetActive(false);
            BestScore.text = "";
            CurrentScore.text = "";
        }

        TargetLetter = letterOptions[Random.Range(0, letterOptions.Length)];

        goal.text = "Click only: " + TargetLetter.ToString().ToUpper();
        timeCount = 0;
        scoreCount = 0;
        Instance = this;
    }

    public void UpdateScore(int add)
    {
        scoreCount += add;
        score.text = ""+scoreCount;
        CurrentScore.text = "Current Score: " + scoreCount;
//        if (scoreCount >= scoreGoal)
//            goalReached = true;
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

        timeCount += Time.deltaTime;
        if(timeCount > timeLimit)
        {
            gameLost = true;
            return;
        }
        time.text = "" + (int)((timeLimit-timeCount)+1);

        if (Input.GetKeyDown(Pause))
        {
            TogglePause();
            PlayAgain.text = "Continue";
        }
    }

    public void TogglePause()
    {
        paused = !paused;
        PauseScreen.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

    public void WinLevel()
    {
        // Load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_lastscore", scoreCount);
        if(scoreCount > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_bestscore", 0))
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_bestscore", scoreCount);
    }

    public void LostLevel()
    {
        // Reload level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_lastscore", scoreCount);
        if (scoreCount > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_bestscore", 0))
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_bestscore", scoreCount);
    }
}
