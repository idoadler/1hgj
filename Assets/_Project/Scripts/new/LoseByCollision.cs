
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseByCollision : MonoBehaviour
{
    public GameObject destroyThis;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "baddy")
        {
            Destroy(destroyThis);
            SceneManager.LoadScene("Secret");
        }
    }
}
