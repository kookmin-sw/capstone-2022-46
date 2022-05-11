using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoes : MonoBehaviour {
    public float moveSpeed = 0.45f;
    public GameObject player;
    public GameObject fragile;

    void Start () {

    }
    void Update () {
        float moveY = moveSpeed * Time.deltaTime;
        //이동할 거리를 지정
        transform.Translate(0, moveY, 0);
    }


    //객체와 충돌할 경우.
    private void OnTriggerEnter2D(Collider2D collision)
    {
      Player playerLogic = player.GetComponent<Player>();

      if (collision.CompareTag("Enemy"))
      {
        Debug.Log("적 기체와 충돌");
        gameObject.SetActive(false);

        if(playerLogic.is_fragile == true)
        {
            shootFragile();
        }

      }
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void shootFragile()
    {
      int f_Num = 5;
      for(int index = 0; index < f_Num; index++)
      {
          Debug.Log(f_Num);
      //  GameObject f = objectManager.MakeObj("bulletBossSisters");
        GameObject f = Instantiate(fragile);
        f.transform.position = transform.position;//위치는 약간 미세조정 필요
        f.transform.rotation = Quaternion.identity;

        Rigidbody2D rigid = f.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / f_Num), Mathf.Sin(Mathf.PI * 2 * index / f_Num));
        rigid.AddForce(dirVec.normalized * 10, ForceMode2D.Impulse);

        Vector3 rotVec = Vector3.forward * 360 * index / f_Num + Vector3.forward * 90;
        f.transform.Rotate(rotVec);
      }

    }
}
