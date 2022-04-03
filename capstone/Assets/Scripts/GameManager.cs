using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public string[] enemyObjs;
    public Transform[] spawnPoints;


    public float nextSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public Text scoreText;
    public GameObject gameOverSet;
    public ObjectManager objectManager;

    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;

    private void Awake()
    {
        spawnList = new List<Spawn>();
        enemyObjs = new string[]{"enemy001", "enemy002", "bossSisters"};
        ReadSpawnFile();
    }
    void ReadSpawnFile()
    {
        //변수 초기화
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;
        //리스폰 파일 읽기
        TextAsset textFile = Resources.Load("stage1") as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);

        while (stringReader != null)
        {
            string line = stringReader.ReadLine();

            if (line == null)
                break;
            //리스폰 데이터 생성
            Spawn spawnData = new Spawn();
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.type = line.Split(',')[1];
            spawnData.point = int.Parse(line.Split(',')[2]);
            spawnList.Add(spawnData);
        }
        //텍스트파일 닫기
        stringReader.Close();
        nextSpawnDelay = spawnList[0].delay;
    }
    void Update()
    {
        curSpawnDelay += Time.deltaTime;
        if (curSpawnDelay > nextSpawnDelay && !spawnEnd)
        {
            SpawnEnemy();
            curSpawnDelay = 0;
        } 
        Player playerLogic = player.GetComponent<Player>();
        //에러나서 잠깐지움.
      //  scoreText.text = string.Format("{0:n0}", playerLogic.score);
    }

    void SpawnEnemy()
    {
        int enemyIndex = 0;
        switch(spawnList[spawnIndex].type)
        {
            case "enemy001":
                enemyIndex = 0;
                break;
            case "enemy002":
                enemyIndex = 1;
                break;
            case "bossSisters":
                enemyIndex = 2;
                break;
        }
        int enemyPoint = spawnList[spawnIndex].point;
        GameObject enemy = objectManager.MakeObj(enemyObjs[enemyIndex]);
        enemy.transform.position = spawnPoints[enemyPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        EnemyBehaviour enemyLogic = enemy.GetComponent<EnemyBehaviour>();
        enemyLogic.player = player;
        enemyLogic.objectManager = objectManager;

        spawnIndex++;
        if(spawnIndex == spawnList.Count)
        {
            spawnEnd = true;
        }
        nextSpawnDelay = spawnList[spawnIndex].delay;
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
