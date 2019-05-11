using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public static int MAIN_SCENE = 1;

	// Update is called once per frame
	private void Update() 
	{
		if (Input.GetKey("escape"))
		{
			BackButtonClicked();
		}
	}

	public static void BackButtonClicked()
	{
		if (SceneManager.GetActiveScene().buildIndex == MAIN_SCENE)
		{
			QuitGame();
		}
		else
		{
			SceneManager.LoadScene(MAIN_SCENE);
		}
	}

	private static void QuitGame()
	{
#if UNITY_EDITOR
		// Application.Quit() does not work in the editor so
		// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
		UnityEditor.EditorApplication.isPlaying = false;
#elif !UNITY_WEBGL
        Application.Quit();
#endif
	}
}
