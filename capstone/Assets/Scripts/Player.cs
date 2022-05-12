using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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

    public Sprite[] char_sprite;
    SpriteRenderer spriteRenderer;
    public bool isHit;

    void Update()
    {
        Move();
        curShotDelay += Time.deltaTime;
        Fire();


    }
    private void Awake()
    {

        if (PlayerPrefs.HasKey("Power")){
            dmg += PlayerPrefs.GetInt("Power");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();//피격표시용

    }
    void Fire()
    {
        if (!Input.GetKey(KeyCode.Space))
             return;


        if (curShotDelay < maxShotDelay)
            return;

        switch (power)
        {
            case 1:
                GameObject bullet = objectManager.MakeObj("bulletPlayer");
                bullet.transform.position = transform.position;
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


        if (col.gameObject.tag == "Ticket")
        {
            GameManager manager = gameManager.GetComponent<GameManager>();
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

        Invoke("OffDamaged", 0.7f);

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


    private void Move(){
      if(Input.GetKey(KeyCode.UpArrow)){
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
}
