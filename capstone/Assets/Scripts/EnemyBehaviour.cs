using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public const float Speed = 2f;
    public GameObject Coin;
    // Start is called before the first frame update
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
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Player")
        {
            //Instantiate(Coin, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}