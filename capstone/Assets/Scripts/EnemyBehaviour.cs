using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public  float Speed = 2f;
    public GameObject Coin;

    //체력 정보.
    public int HP;
    private EnemyData enemyData;
    // Start is called before the first frame update
    void Start()
    {
      //enemyData = new EnemyData(HP);
      enemyData = this.gameObject.AddComponent<EnemyData>();
      enemyData.setHP(HP);
    }

    // Update is called once per frame
    void Update()
    {
        moveControl();

        //체력체크.
        if(enemyData.getHP() <= 0 )
        {
          Destroy(this.gameObject);
        }
    }

    void moveControl()
    {
        float distanceY = Speed * Time.deltaTime;
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
    }

    private void OnTriggerEnter2D(Collider2D col) //���� �浹
    {
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Player")
        {
            enemyData.decreaseHP(10); // 체력 10 감소.
            //Instantiate(Coin, transform.position, transform.rotation);
            //Destroy(this.gameObject);
        }
    }
}
