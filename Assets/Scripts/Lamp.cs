using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public SpriteRenderer lamp;
    public static Lamp Instance;
    public Sprite on;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
        Instance = this;
    }

    public void Switcheru()
    {
        lamp.sprite = on;
    }
}
