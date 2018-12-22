using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Santa : MonoBehaviour
{
    public float upForce;                   //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall?
    public GameObject gift;
    public Sprite santaOn;
    public Sprite santaOff;

    //    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.
    private SpriteRenderer sr;               //Holds a reference to the Rigidbody2D component of the bird.

    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
//        anim = GetComponent<Animator>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Don't allow control if the bird has died.
        if (isDead == false)
        {
            //Look for input to trigger a "flap".
            if (Input.anyKeyDown)
            {
                Instantiate(gift, transform);
                //...tell the animator about it and then...
//                anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
                rb2d.velocity = Vector2.zero;
                //  new Vector2(rb2d.velocity.x, 0);
                //..giving the bird some upward force.
                rb2d.AddForce(new Vector2(0, upForce));
                sr.sprite = santaOn;
            }
            else if (!Input.anyKey)
            {
                sr.sprite = santaOff;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            // Zero out the bird's velocity
            rb2d.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            isDead = true;
            //...tell the Animator about it...
            //        anim.SetTrigger("Die");
            //...and tell the game control about it.
            LevelManager.Instance.gameLost = true;
        }
    }
}