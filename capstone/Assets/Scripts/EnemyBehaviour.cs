using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public string enemyName;
    public int enemyScore;
    public int coinDrop;
    public int ringDrop;
    public int ticketDrop;
    public float maxHP;
    public float health;
    public float Speed;
    public float dmg;

    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bullet;
    public GameObject itemCoin;
    public GameObject itemRing;
    public GameObject itemTicket;
    public GameObject player;
    public ObjectManager objectManager;

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    public const float DestroyYPos = -5; // 미사일이 사라지는 지점



    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//피격표시용
    }


    void OnEnable()
    {
        switch (enemyName)
        {
            case "enemy001":
                health = 15;
                break;
            case "enemy002":
                health = 40;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        moveControl();

        if(transform.position.y <= DestroyYPos)
          {
              gameObject.SetActive(false);
          }
    }
    void moveControl()
    {
        float distanceY = Speed * Time.deltaTime;
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
    }

    private void OnTriggerEnter2D(Collider2D col) //적과 충돌
    {
        Player playerLogic = player.GetComponent<Player>();
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        else if (col.gameObject.tag == "Bullet")
        {
            onHit(playerLogic.dmg);
        }

    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }


    void onHit(float dmg)
    {
        if (health <= 0)
            return;

        health -= dmg;
        //데미지 받은 스프라이트(색깔만 점멸해도 됨)
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);
        ////////////

        if (health <= 0)
        {
            Player playerLogic = player.GetComponent<Player>();
            playerLogic.score += enemyScore;
            int ran = Random.Range(0, 100);//퍼센테이지로 표기
            if (ran < ticketDrop)
            {
                GameObject itemTicket = objectManager.MakeObj("itemTicket");
                itemTicket.transform.position = transform.position;
            }
            else if (ran < ticketDrop + ringDrop)
            {
                GameObject itemRing = objectManager.MakeObj("itemRing");
                itemRing.transform.position = transform.position;
            }
            else
            {
                GameObject itemCoin = objectManager.MakeObj("itemCoin");
                itemCoin.transform.position = transform.position;
            }
            Debug.Log("적 체력 000000");
            gameObject.SetActive(false);
        }
    }

    void ReturnSprite(){
      spriteRenderer.sprite = sprites[0];
    }


}
