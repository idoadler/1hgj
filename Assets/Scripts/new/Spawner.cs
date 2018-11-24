using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawned;
    public int min = 1;
    public int max = 3;
    public float radius;
    public float minTime = 4;
    public float maxTime = 6;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObjects", Random.Range(minTime / LevelManager.Instance.speedDown, 0 / LevelManager.Instance.speedDown));
    }

    private void SpawnObjects()
    {
        int times = Random.Range(min, max);
        for(int i = 0; i < times; i++)
        {
            Instantiate(spawned);

            spawned.transform.position = transform.position + new Vector3((Random.value - 0.5f) * 2 * radius, (Random.value - 0.5f) * 2 * radius, 0);
        } 
        Invoke("SpawnObjects", Random.Range(minTime / LevelManager.Instance.speedDown, maxTime / LevelManager.Instance.speedDown));
    }
}
