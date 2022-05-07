using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pen_Spawn : MonoBehaviour
{

    public GameObject rangeObject;
    public GameObject pen_Right;
    public GameObject pen_Left;

    public float delay;
    public int dir;
    BoxCollider2D rangeCollider;


    void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Spawn());
    }

    Vector2 get_RandomPosition()
    {
      Vector2 basePosition = transform.position;  //오브젝트의 위치
      Vector2 size = rangeCollider.size;                   //box colider2d, 즉 맵의 크기 벡터

      //x, y축 랜덤 좌표 얻기
      float posX;
      if(dir == 1){posX = -2.5f;}
      else{ posX = 2.5f;}

      float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

      Vector2 spawnPos = new Vector2(posX, posY);

      return spawnPos;
    }


    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);

            Vector3 spawnPos = get_RandomPosition();
            if(dir == 1)
            {
                GameObject instance = Instantiate(pen_Right, spawnPos, Quaternion.identity);
            }
            else
            {
                GameObject instance = Instantiate(pen_Left, spawnPos, Quaternion.identity);
            }

            //yield return new WaitForSeconds(delay);
        }

    }


}
