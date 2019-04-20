using UnityEngine;

public class food : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Fish")
        {
            col.GetComponent<fish>().Feed();
            Destroy(gameObject);
        }
        /*
        if (col.tag == "Finish")
        {
            target.gameObject.SetActive(false);
            running = false;
        }
        else if (col.tag == "Score")
        {
            fishs++;
            Destroy(col.gameObject);
            if (fishs >= LevelManager.Instance.target)
            {
                LevelManager.Instance.WinLevel();
            }
        }
        else if (col.tag == "Enemy")
        {
            LevelManager.Instance.LostLevel();
        }*/
    }
}
