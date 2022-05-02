using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_shoes : MonoBehaviour
{
    public int dmg;
    public bool isRotate;
    public float Speed;


    void Start()
    {

    }

    // Update is called once per frame
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
      //  Player playerLogic = player.GetComponent<Player>();
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        else if (col.gameObject.tag == "Bullet")
        {
            //onHit(playerLogic.dmg);
        }

    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
