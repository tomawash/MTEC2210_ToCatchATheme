using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform leftTran;
    public Transform rightTran;

    public float lastSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItem()
    {

        float rndXValue = 0;

        if(lastSpawn >= 0)
        {
            rndXValue = Random.Range(leftTran.position.x, lastSpawn - 1);
        }

        else if(lastSpawn < 0)
        {
            rndXValue = Random.Range(lastSpawn + 1, rightTran.position.x);
        }

        lastSpawn = rndXValue;

        //float rndXValue = Random.Range(leftTran.position.x, rightTran.position.x);
        Vector2 spawnPos = new Vector2(rndXValue, leftTran.position.y);
        Instantiate(itemPrefab, spawnPos, Quaternion.identity);
    }
}
