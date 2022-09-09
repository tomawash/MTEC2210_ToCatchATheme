using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float speed = 5;
    public float health = 10;

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

        Debug.Log("xMove: " + xMove);
        transform.Translate(xMove * speed * Time.deltaTime, 0, 0);

        //transform.position = new Vector3(0, 0, 0);
    }
}
