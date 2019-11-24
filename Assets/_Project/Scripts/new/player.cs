using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class player : MonoBehaviour
{
    public LevelManager manager;
    public Tilemap map;
    public Grid grid;
    public Rigidbody2D body;

    public float moveSpeed = 3.0f;  // Units per second
    
    // Update is called once per frame
    void Update()
    {
 
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, -1 * moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) > 30)
            {
                transform.position = Vector3.zero;
            }
        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(Vector3.right, 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer(Vector3.up, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer(Vector3.down, 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(Vector3.left, 1);
        }*/
    }

    private void OnMouseDown()
    {
        manager.AddScore(1);
        transform.position = Vector3.zero;
    }
}
