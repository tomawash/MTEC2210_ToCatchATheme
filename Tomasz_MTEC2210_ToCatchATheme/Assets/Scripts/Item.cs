using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //speed = Random.Range(3, 15);

        float i = Random.value;

        if (i > 0.75f)
        {
            speed = Random.Range(10, 15);
        }
        else
        {
            speed = Random.Range(1, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
