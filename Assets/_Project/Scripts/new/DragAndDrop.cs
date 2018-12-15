using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DragAndDrop : MonoBehaviour
{
    public DragAndDrop parent;
    public List<DragAndDrop> kids = new List<DragAndDrop>();
    public bool complete = false;
    public Vector3 shift;
    public float area;
    private bool inPlace = false;

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Awake()
    {
        if (parent != null)
        {
            parent.kids.Add(this);
        }
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (inPlace)
        {
            return;
        }

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void Update()
    {
        if (complete)
            return;

        if (parent != null)
        {
            if (inPlace)
            {
                foreach (DragAndDrop d in kids)
                {
                    if (!d.complete)
                        return;
                }

                complete = true;
            }
            else
            {
                if (Vector3.Distance(transform.position, parent.transform.position + shift) < area)
                {
                    transform.position = parent.transform.position + shift;
                    transform.parent = parent.transform;
                    inPlace = true;
                }
            }
        }
        else if(parent == null && kids.Count > 0)
        {
            foreach (DragAndDrop d in kids)
            {
                if (!d.complete)
                    return;
            }

            complete = true;
            LevelManager.Instance.WinLevel();
        }
    }
}