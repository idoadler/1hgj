using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public Text score;
    public Text time;
    public Text goal;
    public GameObject baloon;
    public float minimumHight;

    public int timeStart = 60;
    public int scoreGoal = 100;
    public bool goalReached = false;
    
    private int scoreNum;
    private float timeNum;

    private void Awake()
    {
        goal.text = "Reach:" + scoreGoal + " Worth";
        timeNum = timeStart;
        scoreNum = 0;
        Instance = this;
    }

    public void UpdateScore(int add)
    {
        scoreNum += add;
        score.text = ""+scoreNum;
        if (scoreNum >= scoreGoal)
            goalReached = true;
    }

    private void Update()
    {
        if(baloon.transform.position.y < minimumHight)
        {
            goalReached = true;
        }
        if (goalReached)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }

        timeNum -= Time.deltaTime;
       /* if(timeNum < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }*/
        time.text = "" + (int)(timeNum+1);
    }
}
