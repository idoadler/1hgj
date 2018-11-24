using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private static bool created = false;

    void Awake()
    {
        PlayerPrefs.DeleteKey("bvb" + "_lastscore");
        Toolbox.RegisterComponent<BackButton>();
    }
}
