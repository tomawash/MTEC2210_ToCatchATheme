using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public AudioClip coinClip;
    public AudioClip hazardClip;
    //public AudioSource audioSource;
    public GameManager gm;
    public float speed = 5;
    public float health = 10;

    public float oldpos = 0;

    //public float myVariable;
    //private int myOtherVariable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");

        //Debug.Log("xMove: " + xMove);
        transform.Translate(xMove * speed * Time.deltaTime, 0, 0);

        //transform.position = new Vector3(0, 0, 0);

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
