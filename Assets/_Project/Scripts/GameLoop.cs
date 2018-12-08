using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    void Awake()
    {
        Cursor.visible = true;
        PlayerPrefs.DeleteKey("bvb" + "_lastscore");
        Toolbox.RegisterComponent<BackButton>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
