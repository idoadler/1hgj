using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float Speed = 5;
    public bool Positive = true;
    public string Axis = "Vertical";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis(Axis) != 0 && Input.GetAxis(Axis) > 0 == Positive)
        {
            transform.Rotate(0, 0, Time.deltaTime * Speed);
        }
    }
}
