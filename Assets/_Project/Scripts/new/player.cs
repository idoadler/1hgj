using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class player : MonoBehaviour
{
    public Tilemap map;
    public Grid grid;
    public Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.y < -60 || Mathf.Abs(transform.localPosition.x) > 100)
        {
            LevelManager.Instance.LostLevel();
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

    public void MovePlayer(Vector3 step, int power)
    {
        body.AddForce(step * power * 3, ForceMode2D.Impulse);
/*        if(map.HasTile(grid.WorldToCell(transform.position + step)))
        {
            transform.position += step;
        }*/
    }
}
