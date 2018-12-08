using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public int sceneToLoad = 1;

    public void Invoke()
    {
       SceneManager.LoadScene(sceneToLoad);
    }
}
