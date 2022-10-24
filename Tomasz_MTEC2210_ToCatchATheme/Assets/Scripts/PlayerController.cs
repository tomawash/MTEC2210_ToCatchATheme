using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public AudioClip coinClip;
    public AudioClip hazardClip;
    //public AudioSource audioSource;
    public GameManager gm;
    public float speed = 200;
    public float jumpSpeed = 10;

    private Rigidbody2D rb;

    bool jumping;

    public float health = 10;

    public float oldpos = 0;

    //public float myVariable;
    //private int myOtherVariable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float xMove = Input.GetAxis("Horizontal");

        //Debug.Log("xMove: " + xMove);
        //transform.Translate(xMove * speed * Time.deltaTime, 0, 0);



        //Method 1 - Translation Method
        /*
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        */



        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }

        //Flip sprite
        float temp = gameObject.transform.position.x;

        if (temp > oldpos)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (temp < oldpos)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        oldpos = temp;
    }

    public void FixedUpdate()
    {
        //Method 2 - Velocity method
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }

        if(jumping == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collided");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            gm.IncrementScore(1);
            gm.PlaySound(coinClip);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Hazard")
        {
            gm.PlaySound(hazardClip);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Theme")
        {
            Debug.Log("THEME CHANGE!!!");
        }
        

        //Debug.Log("Triggered");
        //Debug.Log(collision.transform.name);
    }
}
