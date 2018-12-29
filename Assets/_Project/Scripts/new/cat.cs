using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    public GameObject target;
    public float speed = 1;

    private bool running = true;
    private int fishs = 0;

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            transform.position += (target.transform.position - transform.position).normalized * Time.deltaTime * speed;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                running = true;
                target.gameObject.SetActive(true);
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.transform.position = new Vector3(pos.x, pos.y, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
            target.gameObject.SetActive(false);
            running = false;
        }
        else if (col.tag == "Score")
        {
            fishs++;
            Destroy(col.gameObject);
            if (fishs >= LevelManager.Instance.target)
            {
                LevelManager.Instance.WinLevel();
            }
        }
        else if (col.tag == "Enemy")
        {
            LevelManager.Instance.LostLevel();
        }
    }
}
