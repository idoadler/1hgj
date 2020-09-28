using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckShooter : MonoBehaviour
{
    public GameObject projectile;

    void Start()
    {
        InvokeRepeating(nameof(LaunchProjectile), 10.0f, 1f);
    }

    void LaunchProjectile()
    {
        GameObject d = Instantiate(projectile);
        d.transform.position += 3f * Vector3.right * (Random.value - 0.5f) ;
        d.transform.position += 3f * Vector3.up * (Random.value - 0.5f) ;
    }
}
