using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject[] patrolPoints;
    public float speed;

    private int current = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[current].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, patrolPoints[current].transform.position) < 0.5f)
        {
            current++;
            current %= patrolPoints.Length;
        }
    }
}
