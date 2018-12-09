using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Sprite Keeper;
    public Sprite Buzz;
    public AudioSource Audio;
    public SpriteRenderer Renderer;
    
    public float Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = transform.position - Shop.Instance.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.localPosition += transform.right * v * Time.deltaTime * Speed;
        transform.localPosition += transform.up * -h * Time.deltaTime * Speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.name);
        if (col.tag == "Enemy")
        {
            col.GetComponent<RandomizeSprite>().Hit();

            col.tag = "Untagged";
            if (!Audio.isPlaying)
            {
                Audio.Play();
            }
            Renderer.sprite = Buzz;
            Invoke("ResetSprite", 0.3f);
        }
    }

    private void ResetSprite()
    {
        Renderer.sprite = Keeper;
    }
}
