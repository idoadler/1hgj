using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gift : MonoBehaviour
{
    public SpriteRenderer[] parts;
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, colors.Length);
        parts[0].color = colors[i];
        parts[1].color = colors[(i + 1) % colors.Length];
        parts[1].color = colors[(i + 2) % colors.Length];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * LevelManager.Instance.speed;

        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
}
