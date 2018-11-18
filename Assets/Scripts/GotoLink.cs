using UnityEngine;

public class GotoLink : MonoBehaviour
{
    public string link;

    public void Go()
    {
        Application.OpenURL(link);
    }
}
