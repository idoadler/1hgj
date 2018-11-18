using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
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
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			QuitGame();
		}
		else
		{
			SceneManager.LoadScene(0);
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
