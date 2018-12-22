using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float timeBetween = 1;
    public float randomPosDown;

    private void Start()
    {
        Time.timeScale = 2;
        Spawn();
    }

    // Update is called once per frame
    private void Spawn()
    {
        GameObject temp = Instantiate(prefab);
        temp.transform.position = transform.position + Random.value * Vector3.down * randomPosDown;
        Time.timeScale *= 1.02f;


        Invoke("Spawn", Random.value * timeBetween + (timeBetween / 2));
    }
}
