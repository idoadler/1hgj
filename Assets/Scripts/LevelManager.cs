using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance;

    public string correctText;
    public string wrongText;
    private string[] correctWords;
    private string[] correctWordsFixed;
    private string[] wrongWords;
    private int currentWord;

    public Text Letter;
    public Button[] buttons;
    private int currectButton;

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

//    private int scoreCount;
//    private float timeCount;

    private void Awake()
    {
        correctWords = Regex.Replace(correctText.ToLower(), "[^a-zA-Z0-9% ._]", string.Empty).Split(' ');
        correctWordsFixed = correctText.Split(' ');
        currentWord = 0;
        wrongWords = Regex.Replace(wrongText.ToLower(), "[^a-zA-Z0-9% ._]", string.Empty).Split(' ');
        SetNextWord();

        //goal.text = "Find the correct battery";
        Instance = this;
    }

    public void SetNextWord()
    {
        if (currentWord >= correctWords.Length)
        {
            goalReached = true;
            return;
        }

        currectButton = Random.Range(0, buttons.Length);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != currectButton)
            {
                buttons[i].GetComponentInChildren<Text>().text = 'V' + wrongWords[Random.Range(0, wrongWords.Length)].Substring(1);
            }
            else
            {
                buttons[i].GetComponentInChildren<Text>().text = 'V' + correctWords[currentWord].Substring(1);
            }
        }
    }

    public void ButtonClicked(int button)
    {
        if (currentWord == 0)
        {
            Letter.text = "";
        }

        if (button == currectButton)
        {
            Letter.text += ' ' + correctWordsFixed[currentWord];
            currentWord++;
            SetNextWord();
        }
        else
        {
            gameLost = true;
        }
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
    }
    
    public void WinLevel()
    {
        // Load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LostLevel()
    {
        // Reload level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
