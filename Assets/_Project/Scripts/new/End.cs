using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public int nextScene = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextScene);
    }
}
