using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Slider damageBar;
    public float MoveSpeed = 0.3f;
    public float HealthLossSpeed = 0.3f;
    private float damage = 0;
    public Transform Top;
    public Transform Bottom;

    private void Awake()
    {
        Instance = this;
    }

    internal void Hit(float time)
    {
        damage += time * HealthLossSpeed;
        damageBar.value = damage;
        if (damage > 1)
            LevelManager.Instance.gameLost = true;
    }

    private void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, v, 0) * MoveSpeed;
    }
}
