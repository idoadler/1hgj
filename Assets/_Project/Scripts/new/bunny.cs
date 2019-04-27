using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bunny : MonoBehaviour
{
    public Tilemap map;
    public Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        MoveBunny();
    }

    public void MoveBunny()
    {
        if (map.HasTile(grid.WorldToCell(transform.position + Vector3.right)))
        {
            transform.position += Vector3.right;
        }
        else if (map.HasTile(grid.WorldToCell(transform.position + Vector3.up)))
        {
            transform.position += Vector3.up;
        }
        else if (map.HasTile(grid.WorldToCell(transform.position + Vector3.down)))
        {
            transform.position += Vector3.down;
        }
        else
        {
            Destroy(gameObject);
        }
        Invoke("MoveBunny", 0.15f);
    }
}
