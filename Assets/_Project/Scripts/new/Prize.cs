using UnityEngine;

public class Prize : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelManager.Instance.target--;
            LevelManager.Instance.score.text = "" + LevelManager.Instance.target;
            if (LevelManager.Instance.target == 0)
                LevelManager.Instance.WinLevel();
            Destroy(gameObject);
        }
    }
}
