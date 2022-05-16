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

  //  public Animator playerDead;
    public GameObject dead;
    public GameObject gameOverImg;
    public GameObject bossDead;
    int bossFlag = 0;

    public GameObject background;


    //private GameObject playerData;

    private void Awake()
    {
        GameLoad();

        spawnList = new List<Spawn>();
        enemyObjs = new string[]{"enemy001", "enemy002", "enemy003"};
        ReadSpawnFile();
        //SpawnBoss();

        Invoke("SpawnBoss",bossSpawnDelay);

        //playerDead = player.GetComponent<Animator>();
        //playerData = GameObject.Find("Player");


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
        //메인 게임 들어오면 플레이어 활성화.
        if (SceneManager.GetActiveScene().buildIndex == 3)
         {
             Player.instance.checkMainGame();
         }


        if (Input.GetButtonDown("Cancel")) // 메뉴 조작
        {
            if (shopSet.activeSelf)
                shopSet.SetActive(false);
            else if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else menuSet.SetActive(true);
        }

        if (menuSet.activeSelf || shopSet.activeSelf) // 메뉴 실행시 게임 일시정지
            Time.timeScale = 0f;
        else Time.timeScale = 1f;

        curSpawnDelay += Time.deltaTime;
        if (curSpawnDelay > nextSpawnDelay && !spawnEnd)
        {
            SpawnEnemy();
            curSpawnDelay = 0;
        } //스폰


        //Player playerLogic = player.GetComponent<Player>();
        //Player playerLogic = FindObjectOfType<Player>();
        //GameOb playerLogic = gameObject.Find("Player");


        // 게임종료 체크 (플레이어 체력으로)
        if(Player.health <= 0 )
        {
            Time.timeScale = 0.0f;
            GameOver();


        }


        if(bossFlag == 1 && bossSisters.health <= 0)
        {
          Debug.Log("보스 죽음 애니 시작");
          Time.timeScale = 0.0f;
          GameClear();
        }

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
            case "enemy003":
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

        spawnIndex++;//이거때문에 오류 나긴하는데 스테이지에서 과하게 소환 안하면 괜찮을듯
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
      bossFlag = 1;
      //bossDead.transform.position = boss.transform.position;  //위치잡아줌

    }



    public void GameSave()
    {
        //Player playerData = player.GetComponent<Player>();

        //PlayerPrefs.SetInt("InkBottle", playerData.ink);//이게 기본 템플릿, 이걸 따라서 저장해야 할 데이터를 복제하면 됨
        PlayerPrefs.SetInt("InkBottle", Player.instance.ink);
        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        //Ink = PlayerPrefs.GetInt("InkBottle");
    }

    public void RespawnPlayer()
    {
        player.transform.position = Vector3.down * 3.5f;
        player.SetActive(true);

        //Player playerData = player.GetComponent<Player>();

        //playerData.isHit = false;
        Player.instance.isHit = false;

    }

    public void GameOver()
    {
        dead.SetActive(true); //애니메이션 활성
        dead.transform.position = Player.instance.transform.position;  //위치잡아줌
        //player.SetActive(false);  //플레이어 겹쳐서 안보이게함
        Player.instance.spriteRenderer.color = new Color(1, 1, 1, 0f);


        //여기에 gameover텍스트랑 씬 이동 구현 하면댐.
        gameOverImg.SetActive(true);
        StartCoroutine(goGameOverScene());
        //Loading.LoadScene("Game_Lobby");

    }

    IEnumerator goGameOverScene()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        //Loading.LoadScene("Game_Lobby");

         Time.timeScale = 1f;
         //MainGameReset();
         //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         Player.health = 100;
         Player.instance.transform.position = new Vector3(0, -4, 0);
         //Player.instance.maxShotDelay = 0.15f;
         //Player.instance.gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

         Loading.LoadScene("Game_Lobby");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    void GameClear()
    {
        bossDead.SetActive(true); //애니메이션 활성

        //여기 화면 씬 전화 코드 추가

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

    void Pause()
    {
        Time.timeScale = 0f;
    }
}
