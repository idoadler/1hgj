using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance;
    public SpriteRenderer[] Broken;
    public AudioClip[] Clips;
    public AudioSource Audio;
    private int current;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.name);
        if (col.tag == "Enemy")
        {
            Destroy(col.gameObject);
            if(current < Broken.Length)
            {
                Broken[current].gameObject.SetActive(true);
                Audio.clip = Clips[current];
                Audio.Play();
                current++;
            }
            else
            {
                Invoke("EndGame", 1);
            }
        }
    }

    private void EndGame()
    {
        LevelManager.Instance.gameLost = true;
    }
}
