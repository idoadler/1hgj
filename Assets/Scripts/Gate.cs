﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bull")
            SceneManager.LoadScene("Menu");
    }
}
