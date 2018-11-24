using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideways : MonoBehaviour
{

    public float speed = 3;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime * LevelManager.Instance.speedDown;
    }
}
