using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoes : MonoBehaviour {
    public float moveSpeed = 0.45f;

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
      if (collision.CompareTag("Enemy"))
      {
        Debug.Log("적 기체와 충돌");
        gameObject.SetActive(false);
      }
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
