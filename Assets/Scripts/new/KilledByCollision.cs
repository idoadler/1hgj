
using UnityEngine;

public class KilledByCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        LevelManager.Instance.gameLost = true;
    }
}
