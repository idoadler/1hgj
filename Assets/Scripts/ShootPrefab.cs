using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    public GameObject prefab;
    public float maxTimeForNextShoot = 5;
    public float decreeser = 0.95f;
    public float range = 10f;

    void Start()
    {
        StartCoroutine(ShootDog());
    }

    IEnumerator ShootDog()
    {
        yield return new WaitForSeconds(Random.value * maxTimeForNextShoot);
        maxTimeForNextShoot *= decreeser;
        GameObject dog = Instantiate(prefab, transform);
        dog.transform.localPosition = new Vector3(Random.Range(-range, range), 0, 1);
        StartCoroutine(ShootDog());
    }
}
