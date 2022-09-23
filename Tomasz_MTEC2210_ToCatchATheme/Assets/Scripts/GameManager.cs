using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject [] itemPrefab;
    public Transform leftTran;
    public Transform rightTran;

    public float lastSpawn = 0;
    public int score = 0;

    public TextMeshPro scoreText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
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

        int index = Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[index], spawnPos, Quaternion.identity);
    }

    public void IncrementScore(int value)
    {
        score += value;
    }
}
