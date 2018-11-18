using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int speed = 10;
    public Vector3 direction = Vector3.zero;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        direction = Input.GetAxis("Vertical") * Vector3.up + Input.GetAxis("Horizontal") * Vector3.right;
        transform.position += Time.deltaTime * speed * direction;
	}
}
