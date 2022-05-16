using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSisters : MonoBehaviour
{
    public string enemyName;
    public int enemyScore;
    //public int coinDrop;
    //public int ringDrop;
    //public int ticketDrop;
    public float maxHP;
    public static float health;
    public float Speed;
    public float dmg;

    public float maxShotDelay;
    public float curShotDelay;
    public float fingerDelay;

    public GameObject bullet;
    public GameObject itemCoin;
    //public GameObject itemRing;
    //public GameObject itemTicket;
    public GameObject player;
    public ObjectManager objectManager;
    //public bossFoot bossfoot;


    public GameObject boss_foot_R;
    public GameObject boss_foot_L;

    //쿵쾅패턴 위한
    public GameObject m_b_f_R;
    public GameObject m_b_f_L;

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    //private Animator foot_S;
    public Animator anim;
    //public GameObject bossDead;

    public int patternIndex = 5;
    public int curPatternCount;
    public int[] maxPatternCount;
    public bool downOver = false;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//피격표시용
        anim = GetComponent<Animator>();
        objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();

        //foot_S = GetComponent<Animator>();

    }

    void Update()
    {
        moveControl();





    }


    //생성됨.
    void OnEnable()
    {
      health = maxHP;
      Invoke("Stop", 2.2f);
    }

    void Stop() //정지부분
    {
        Debug.Log("stop");
        Speed = 0;
        Invoke("Think", 2f);
        downOver = true;
    }
    void Think()
    {
        if(health >= (maxHP/4)*3)
        {
            phase_One();
        }
        else if(health >= (maxHP/4)*2)
        {
            phase_Two();
        }
        else
        {
            phase_Three();
        }

    }






//원형 패턴
    void FireRight()
    {
        int bulletNum = 20;
        for(int index = 0; index < bulletNum; index++)
        {
            Debug.Log(index);
            GameObject bullet = objectManager.MakeObj("bulletBossSisters");
            //Debug.Log("보스신발 생성");
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




  //발 패턴 (왼쪽)
    void kickLeft()
    {

        Debug.Log("왼쪽 발 패턴");
        Instantiate(boss_foot_L);

    }

    //발 패턴 (오른쪽)
    void kickRight()
    {
        Debug.Log("오른쪽 발 패턴");
        Instantiate(boss_foot_R);

    }

    //발 쿵쾅쿵쾅 패턴
    void megalodon()
    {
      Debug.Log("발 쿵쾅쿵쾅 패턴");

      Instantiate(m_b_f_L);
      Invoke("megal_R",0.2f);

    }

    void megal_R()
    {
      Instantiate(m_b_f_R);
    }

    //s자 패턴
    void finger_S(int dir)
    {
        float x_dir ;
        if(dir == 0){x_dir = Random.Range(0f, 1.5f); } //0이면 오른쪽
        else{ x_dir = Random.Range(-3f, -1f); }
        StartCoroutine(finger_spawn(x_dir));
    }

     IEnumerator finger_spawn(float x_dir)
    {
        for(int i = 0; i < 10 ; i ++)
        {
            GameObject finger = objectManager.MakeObj("bossFinger");
            finger.transform.position = new Vector3(x_dir, 2.5f, 0);
            //finger.transform.position = transform.position;
            yield return new WaitForSeconds(0.2f);  //손가락 이동속도에 따라 달라짐, 절대 시간 써보는거 고려
        }

    }

//발이랑 손가락 두개나옴
    void foot_finger()
    {
        int dir = Random.Range(0, 2); //0이면 왼쪽, 1이면 오른쪽으로

        if(dir == 0)  //왼쪽발 나오고, 오른쪽 탄막공격
        {
            kickLeft();
            finger_S(dir);

        }
        else
        {
            kickRight();
            finger_S(dir);
        }

    }


    void phase_One()
    {
        //yield return new WaitForSeconds(3f);
        Debug.Log("phase_One 실행중");
        FireRight();
        //yield return new WaitForSeconds(1f);
        Invoke("Think", 3f);
    }

    void phase_Two()
    {
        //yield return new WaitForSeconds(2f);
        int pattern = Random.Range(0, 5);
        Debug.Log("패턴 넘버 : " + pattern);
        switch(pattern)
        {

            case 0 :
            kickLeft();
            break;

            case 1 :
            kickRight();
            break;

            default :
            FireRight();
            break;

        }

        Invoke("Think", 3f);

    }

    void phase_Three()
    {
        //yield return new WaitForSeconds(2f);
        int pattern = Random.Range(0, 5);

        switch(pattern)
        {

            case 0 :
            foot_finger();
            break;

            case 1 :
            megalodon();
            break;


            default :
            FireRight();
            break;

        }

        Invoke("Think", 3f);
    }


/*
    IEnumerator phase_Four()
    {

    }

    IEnumerator phase_Five()
    {

    }
*/

    void moveControl()
    {
        float distanceY = Speed * Time.deltaTime;
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
    }

    private void OnTriggerEnter2D(Collider2D col) //적과 충돌
    {
        Player playerLogic = player.GetComponent<Player>();
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("boss 받는 데미지 : " + playerLogic.dmg);

            onHit(playerLogic.dmg);
        }
        else if(col.gameObject.tag == "Player")
        {
          //gameObject.SetActive(false);
        }

    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }




    void onHit(float dmg)
    {
      Debug.Log("onhit in");
        if (health <= 0)
            return;

        health -= dmg;
        Debug.Log("boss 체력 감소");
        //spriteRenderer.color = new Color(1, 1, 1, 0.8f);
        //spriteRenderer.material.color = new Color(255, 167, 167, 255);

        spriteRenderer.material.color = new Color(255/255f , 167/255f, 167/255f);
        Invoke("OffDamaged", 0.1f);
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

            Debug.Log("boss 체력 000000");
            gameObject.SetActive(false);

        }
    }

    void OffDamaged()
    {
        //spriteRenderer.color = new Color(1, 1, 1, 1f);
        spriteRenderer.material.color = Color.white;
    }

    void ReturnSprite(){
      spriteRenderer.sprite = sprites[0];
    }


}
