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
    Animator anim;

    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//피격표시용
        if (enemyName == "Boss")
            anim = GetComponent<Animator>();
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

                /*
            case "bossSisters":
                health = 100;
                Invoke("Stop", 2);
                break;
                */
        }
    }

    void Stop() //정지부분 이거 동영상이랑 다름.
    {
        Debug.Log("stop");
        Speed = 0;
        Invoke("Think", 2f);
    }
    void Think()
    {
        /*
        patternIndex = patternIndex == 1 ? 0 : patternIndex + 1;
        curPatternCount = 0;

        switch (patternIndex)
        {
            case 0:
                FireRight();
                break;
            case 1:
                PunchLeft();
                break;
        }
        */
        FireRight();

    }
    void FireRight()
    {
        int bulletNum = 20;
        for(int index = 0; index < bulletNum; index++)
        {
            Debug.Log(index);
            GameObject bullet = objectManager.MakeObj("bulletBossSisters");
            bullet.transform.position = transform.position;//위치는 약간 미세조정 필요
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / bulletNum), Mathf.Sin(Mathf.PI * 2 * index / bulletNum));
            rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * index / bulletNum + Vector3.forward * 90;
            bullet.transform.Rotate(rotVec);
        }

        curPatternCount++;

/*
        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireRight", 0.3f); // 재시전
        else
            Invoke("Think", 3); // 다음 패턴으로

  */
    }
    void PunchLeft()
    {
        Debug.Log("왼쪽 때리기.");
        curPatternCount++;
        //구현 아직 안함. 스프라이트가 필요
        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("PunchLeft", 4); // 재시전
        else
            Invoke("Think", 3f); // 다음 패턴으로
    }

    void Update()
    {
        moveControl();
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
          Debug.Log("잡몹 받는 데미지 : " + playerLogic.dmg);
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
      /*  if(enemyName == "bossSisters")
        {
            anim.SetTrigger("OnHit"); // 보스 피격시 애니메이션 출력
        }
        else
        {
            spriteRenderer.sprite = sprites[1];
            Invoke("ReturnSprite", 0.1f);
        }*/

        if (health <= 0)
        {
            Player playerLogic = player.GetComponent<Player>();
            playerLogic.score += enemyScore;
            int ran = enemyName == "bossSisters" ? 0 : Random.Range(0, 100);//퍼센테이지로 표기
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
