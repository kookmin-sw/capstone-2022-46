using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoes : MonoBehaviour {
    public float moveSpeed = 0.45f;
    public float DestroyYPos; // 미사일이 사라지는 지점
    //총알이 움직일 속도를 상수로 지정
    void Start () {

    }
    void Update () {
        float moveY = moveSpeed * Time.deltaTime;
        //이동할 거리를 지정
        transform.Translate(0, moveY, 0);
        //이동을 반영

        //미사일이 한계위치 넘어서면 제거.
        if(transform.position.y >= DestroyYPos)
        {
          GetComponent<Collider2D>().enabled = false;
        }


    }


    //객체와 충돌할 경우.
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Enemy"))
      {
        Debug.Log("적 기체와 충돌");
        GetComponent<Collider2D>().enabled = false;
      }
    }
}
