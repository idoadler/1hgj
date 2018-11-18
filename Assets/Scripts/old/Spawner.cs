using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float waitingTime = 1;
    public GameObject prefab;

    public void Spawn()
    {
        Instantiate(prefab, transform);
        float temp = waitingTime;
        Invoke("Spawn", temp);
        waitingTime *= 0.9f;
    }

    public void Stop()
    {
        CancelInvoke();
    }
}
