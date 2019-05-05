using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class player : MonoBehaviour
{
    public Tilemap map;
    public Grid grid;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(Vector3.left);
        }
    }

    public void MovePlayer(Vector3 step)
    {
        if(map.HasTile(grid.WorldToCell(transform.position + step)))
        {
            transform.position += step;
        }
    }
}
