using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYSpawner : MonoBehaviour
{
    public GameObject x;
    public GameObject y;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnRandom();
        }

        SpawnRandomRepeat();
    }

    private void SpawnRandomRepeat()
    {
        SpawnRandom();
        Invoke("SpawnRandomRepeat", Random.value * 0.5f);
    }

    private void SpawnRandom()
    {
        float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        GameObject l = Instantiate(Random.value > .5f ? x : y, spawnPosition, Quaternion.identity);
        l.transform.Rotate(0, 0, Random.Range(0, 360));
    }
}
