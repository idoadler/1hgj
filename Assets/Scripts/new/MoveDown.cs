﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * LevelManager.Instance.speedDown * Time.deltaTime;
    }
}