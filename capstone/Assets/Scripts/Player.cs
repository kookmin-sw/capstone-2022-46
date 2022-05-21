using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // 싱글턴
    public static Player instance = null;
    public FloatingJoystick joy;
    public static float health = 100;
    public float Speed = 3f;
    public float dmg;
    public float dmg_F;
    public int maxPower;
    public int power;
    public float maxShotDelay;
    public float curShotDelay;
    public int score;
    public int ink;
    public int ring;

    public bool is_fragile = false;

    public GameObject enemyAtk;
    public GameObject bullet;

    public GameManager gameManager;
    public ObjectManager objectManager;
    public GameObject testob;


    public Sprite[] char_sprite;
    public SpriteRenderer spriteRenderer;
    public bool isHit;
    public bool isMaingame;
    
    void Update()
    {
        Move();
        curShotDelay += Time.deltaTime;
        //Fire();

        if (SceneManager.GetActiveScene().buildIndex != 3)
         {
             gameObject.SetActive(false);
             isMaingame = false;
         }



    }
    private void Awake()
    {
        //objectManager = GameObject.Find("ObjectManager");
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //objectManager = testob.GetComponent<ObjectManager>();

        if (PlayerPrefs.HasKey("Power")){
            dmg += PlayerPrefs.GetInt("Power");
        }
        if (PlayerPrefs.HasKey("Speed"))
        {
            Speed += PlayerPrefs.GetInt("Speed") / 10;
        }
        if (PlayerPrefs.HasKey("AtkSpd"))
        {
            for(int i = 0; i< PlayerPrefs.GetInt("AtkSpd"); i++)
                maxShotDelay += 1;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();//피격표시용

        this.transform.position = new Vector3(0, -4, 0);

        health = 100;

        //this.spriteRenderer.color = new Color(1, 1, 1, 1f);


      //  DontDestroyOnLoad(gameObject);

/*
        var obj = FindObjectsOfType<Player>();

        if (obj.Length == 1)
        {
          DontDestroyOnLoad(gameObject);

        }
        else{Destroy(gameObject);}
*/
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
              Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }



    }


    void Fire()
    {
        //if (!Input.GetKey(KeyCode.Space))
          //   return;


        if (curShotDelay < 1/maxShotDelay)
            return;

        switch (power)
        {
            case 1:
                //Debug.Log("지금 1 ");
                //GameObject bullet = objectManager.MakeObj("bulletPlayer");
                GameObject bullet = GameObject.Find("ObjectManager").GetComponent<ObjectManager>().MakeObj("bulletPlayer");
                //Debug.Log("지금 2 ");
                bullet.transform.position = transform.position;
              //  Debug.Log("지금 3 ");
                curShotDelay = 0;
                break;
            case 2:// 파워업 상태
                GameObject bulletR = objectManager.MakeObj("bulletPlayer");
                GameObject bulletL = objectManager.MakeObj("bulletPlayer");
                bulletR.transform.position = transform.position + Vector3.right * 0.1f;
                bulletL.transform.position = transform.position + Vector3.left * 0.1f;
                break;
        }
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyBehaviour enemy = col.gameObject.GetComponent<EnemyBehaviour>();
            health -= enemy.dmg;
            Debug.Log("적과 플레이어 충돌");
            OnDamaged(col.transform.position);
            /*
            if (health <= 0)
            {
                GameManager manager = gameManager.GetComponent<GameManager>();
                manager.GameOver();
            }
            */
            //gameObject.SetActive(false);

        }

        if(col.gameObject.tag == "Pen" || col.gameObject.tag == "finger")
        {

          health -= 10; //피 10퍼 감소.
          Debug.Log("팬과 플레이어 충돌");
          //enemyAtk.gameObject.SetActive(false);
          OnDamaged(col.transform.position);

          /*
          if (health <= 0)
          {

              GameManager manager = gameManager.GetComponent<GameManager>();
              manager.GameOver();
          }
          */
        }

        //보스 발바닥 부분 Test
        if(col.gameObject.tag == "Boss")
        {

          health -= health/2; //피 50퍼 감소.
          Debug.Log("다리와 플레이어 충돌");
          //enemyAtk.gameObject.SetActive(false);
          OnDamaged(col.transform.position);
          /*
          if (health <= 0)
          {

              GameManager manager = gameManager.GetComponent<GameManager>();
              manager.GameOver();
          }
          */
        }


        if (col.gameObject.tag == "Ticket")//티켓 습득 시 상점 호출
        {
            GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            //GameObject.Find("ObjectManager").GetComponent<ObjectManager>().MakeObj("bulletPlayer");
            manager.shopSet.SetActive(true);
        }

    }

    void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 10;

        spriteRenderer.sprite = char_sprite[1];  //이미지 바꿈

        spriteRenderer.color = new Color(1, 1, 1, 0.6f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        StartCoroutine(KnockBack(dirc));

        Invoke("OffDamaged", 0.4f);

    }

    void OffDamaged()
    {
        gameObject.layer = 7;
        spriteRenderer.sprite = char_sprite[0];
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    IEnumerator KnockBack(float dir)
    {
      float ktime = 0;
      float speed = 6f;
      while(ktime < 0.2f )
      {
          transform.Translate(Vector2.left * speed *Time.deltaTime * -1 * dir);
          ktime += Time.deltaTime;
          yield return null;
      }
    }

    public void checkMainGame()
    {

        if(gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);

        }
        //gameObject.SetActive(true);
        //this.transform.position = new Vector3(0, -4, 0);
    }




    private void Move(){
        float x = joy.Horizontal;
        float y = joy.Vertical;
        Vector2 moveVec = new Vector2(x, y);
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.MovePosition(rigid.position + moveVec * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow)){
        // Translate는 현재 위치에서 ()안에 들어간 값만큼 값을 변화시킨다
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
        // Time.deltaTime은 모든 기기(컴퓨터, OS를 망론하고)에 같은 속도로 움직이도록 하기 위한 것
      }

      // ↓ 방향키를 누를 때
      if(Input.GetKey(KeyCode.DownArrow)){
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
      }

      // → 방향키를 누를 때
      if(Input.GetKey(KeyCode.RightArrow)){
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
      }

      // ← 방향키를 누를 때
      if(Input.GetKey(KeyCode.LeftArrow)){
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
      }

      //이동제한.
      Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
      viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
      viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
      Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
      transform.position = worldPos; //좌표를 적용한다.
    }
    public void Shoot()
    {
        Fire();
    }
}
