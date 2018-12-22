using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aruba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * LevelManager.Instance.speed;
        if(transform.position.x < -50)
        {
            Destroy(gameObject);
        }
    }
}
