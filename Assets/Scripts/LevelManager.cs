using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance;

    public Spawner spawner;

    public float timeForAttack;
    public float timeGoing = 0;
    public GameObject[] blocks;
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

//    private int scoreCount;
    private float timeCount;

    private void Awake()
    {
        //goal.text = "Find the correct battery";
        Instance = this;
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

        if (timeForAttack > 0)
        {
            timeForAttack -= Time.deltaTime;
            time.text = "" + (int)(timeForAttack + 1);
        }
        else if (timeForAttack < 0)
        {
            timeForAttack = 0;
            timeTitle.text = "Protect:";
            spawner.Spawn();
            if (DragAndDrop.DraggedInstance != null)
            {
                DragAndDrop.DraggedInstance.GetComponent<Rigidbody2D>().isKinematic = false;
                DragAndDrop.DraggedInstance = null;
            }
        } else
        {
            timeGoing += Time.deltaTime;
            time.text = "" + (int)(timeGoing);
        }
    }
    
    public void WinLevel()
    {
        // Load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LostLevel()
    {
        foreach(GameObject g in blocks)
        {
            g.transform.position += Vector3.up * 0.2f;
        }
        gameLost = false;
        spawner.Stop();
        Invoke("ShowMenu", 1);
        timeForAttack = 0;
        if (timeGoing > 0)
        {
            CurrentScore.text = "Nice job! You protected the egg for: " + (int)(timeGoing+1) + " seconds";
        }
        else
        {
            CurrentScore.text = "You destroyd the egg! Don't do it!";
        }
    }

    public void ShowMenu()
    {
        PauseScreen.SetActive(true);
    }

    public void Restart()
    {
        // Reload level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
