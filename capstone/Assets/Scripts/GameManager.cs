using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string[] enemyObjs;
    public Transform[] spawnPoints;
    

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public Text scoreText;
    public GameObject gameOverSet;
    public ObjectManager objectManager;

    private void Awake()
    {
        enemyObjs = new string[]{"enemy001", "enemy002"};
    }
    void Update()
    {
        curSpawnDelay += Time.deltaTime;
        if (curSpawnDelay >= maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }
        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);
    }
    
    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 2);
        int ranPoint = Random.Range(0, 13);
        GameObject enemy = objectManager.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoints[ranPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        EnemyBehaviour enemyLogic = enemy.GetComponent<EnemyBehaviour>();
        enemyLogic.player = player;
        enemyLogic.objectManager = objectManager;
    }
    
    public void RespawnPlayer()
    {
        player.transform.position = Vector3.down * 3.5f;
        player.SetActive(true);

        Player playerLogic = player.GetComponent<Player>();
        playerLogic.isHit = false;
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }
    public void GoUpgrade()
    {
        SceneManager.LoadScene("Upgrade");
    }
}
