using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float health = 100;
    public float Speed = 3f;
    public float dmg;
    public int maxPower;
    public int power;
    public float maxShotDelay;
    public float curShotDelay;
    public int score;
    public int money = 0;
    public int ring = 0;
    public bool ticket = false;

    public GameObject enemyAtk;
    public GameObject bullet;

    public GameManager gameManager;
    public ObjectManager objectManager;
    public bool isHit;

    void Update()
    {
        Move();
        curShotDelay += Time.deltaTime;
        Fire();
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
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyBehaviour enemy = enemyAtk.GetComponent<EnemyBehaviour>();
            health -= enemy.dmg;
            Debug.Log("적과 플레이어 충돌");
            enemy.gameObject.SetActive(false);
            if(health <= 0)
            {
                GameManager manager = gameManager.GetComponent<GameManager>();
                manager.GameOver();
            }

        }

    }
*/


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyBehaviour enemy = col.gameObject.GetComponent<EnemyBehaviour>();
            health -= enemy.dmg;
            Debug.Log("적과 플레이어 충돌");
            //enemyAtk.gameObject.SetActive(false);
            if(health <= 0)
            {
                GameManager manager = gameManager.GetComponent<GameManager>();
                manager.GameOver();
            }
            //gameObject.SetActive(false);

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
