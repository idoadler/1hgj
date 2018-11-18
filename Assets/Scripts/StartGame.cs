using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    public void StartMain()
    {
        SceneManager.LoadScene("Main");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
