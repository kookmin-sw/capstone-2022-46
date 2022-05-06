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
    public float bossSpawnDelay;

    public GameObject player;
    public GameObject boss;
    public Text scoreText;
    public GameObject gameOverSet;
    public GameObject menuSet;
    public GameObject shopSet;
    public ObjectManager objectManager;

    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;

    public int Ink = 0;

    private void Awake()
    {
        GameLoad();
        
        spawnList = new List<Spawn>();
        enemyObjs = new string[]{"enemy001", "enemy002"};
        ReadSpawnFile();
        //SpawnBoss();
        Invoke("SpawnBoss",bossSpawnDelay);
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
            Spawn spawnData = gameObject.AddComponent<Spawn>();
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

        if (Input.GetButtonDown("Cancel")) // 메뉴 조작
        {
            if (menuSet.activeSelf && shopSet.activeSelf)
                shopSet.SetActive(false);
            else if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else menuSet.SetActive(true);
        }

        if (menuSet.activeSelf) // 메뉴 실행시 게임 일시정지
            Time.timeScale = 0f;
        else Time.timeScale = 1f;

        curSpawnDelay += Time.deltaTime;
        if (curSpawnDelay > nextSpawnDelay && !spawnEnd)
        {
            SpawnEnemy();
            curSpawnDelay = 0;
        } //스폰
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

    void SpawnBoss()
    {
      Debug.Log("보스생성함");
      Instantiate(boss);

    }



    public void GameSave()
    {
        Player playerData = player.GetComponent<Player>();
        PlayerPrefs.SetInt("InkBottle", playerData.money);//이게 기본 템플릿, 이걸 따라서 저장해야 할 데이터를 복제하면 됨
        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        Ink = PlayerPrefs.GetInt("InkBottle");
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
    public void GoShop()
    {
        shopSet.SetActive(true);
    }
    public void GameExit()
    {
        GameSave();
        Application.Quit();
    }
}
