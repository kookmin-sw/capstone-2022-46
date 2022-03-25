using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    Vector3[] positions = new Vector3[5];
    public GameObject enemy;
    public bool isSpawn = false;

    public float spawnDelay = 1.5f;
    float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        CreatePositions();
    }
    void CreatePositions()
    {
        float viewPosY = 1.2f;
        float gapX = 1f/6f;
        float viewPosX = 0f;
        
        for(int i=0; i<positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 WorldPos = Camera.main.ViewportToWorldPoint(viewPos);
            WorldPos.z = 0f;
            positions[i] = WorldPos;
        }
    }

    void SpawnEnemy()
    {
        if(isSpawn == true)
        {
            if(spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);
                Instantiate(enemy, positions[rand], Quaternion.identity);
                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
}
