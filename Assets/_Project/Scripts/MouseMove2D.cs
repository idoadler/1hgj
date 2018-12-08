using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove2D : MonoBehaviour
{

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.paused)
            return;

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mousePosition.x < -8)
        {
            mousePosition.x = -8;
        } else if (mousePosition.x > 8)
        {
            mousePosition.x = 8;
        }

        if (mousePosition.y < -4)
        {
            mousePosition.y = -4;
        } else if (mousePosition.y > 4)
        {
            mousePosition.y = 4;
        }

        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

    }
}