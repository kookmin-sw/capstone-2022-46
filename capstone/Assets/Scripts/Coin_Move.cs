using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Move : MonoBehaviour
{
    public  float Speed = 2f;
    public float DestroyYPos; // 미사일이 사라지는 지점


    // Update is called once per frame
    void Update()
    {
        moveControl();

        if(transform.position.y <= DestroyYPos)
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
        if (col.gameObject.tag == "Player" )
        {
            GoldState.instance.AddScore(50);
            Destroy(this.gameObject);
        }
    }

}
