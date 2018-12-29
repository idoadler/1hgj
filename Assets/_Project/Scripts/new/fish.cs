using UnityEngine;

public class fish : MonoBehaviour
{
    public Sprite[] fishes;
    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend.sprite = fishes[Random.Range(0, fishes.Length)];
        LevelManager.Instance.target++;
    }
}
