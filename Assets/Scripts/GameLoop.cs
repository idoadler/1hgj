using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private static bool created = false;

    void Awake()
    {
        Toolbox.RegisterComponent<BackButton>();
    }
}
