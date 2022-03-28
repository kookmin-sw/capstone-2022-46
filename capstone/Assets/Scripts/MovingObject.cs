using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float Speed = 3f;

    //체력 정보.
    public float HP;
    private PlayerData playerData;

    void Start()
    {
      //playerData = this.gameObject.AddComponent<PlayerData>();
      //playerData.setHP(HP);
      PlayerData.HP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //체력체크.
        
    }

    private void Move(){
      if(Input.GetKey(KeyCode.UpArrow)){
        // Translate는 현재 위치에서 ()안에 들어간 값만큼 값을 변화시킨다
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
        // Time.deltaTime은 모든 기기(컴퓨터, OS를 망론하고)에 같은 속도로 움직이도록 하기 위한 것
      }

      // ↓ 방향키를 누를 때
      if(Input.GetKey(KeyCode.DownArrow)){
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
      }

      // → 방향키를 누를 때
      if(Input.GetKey(KeyCode.RightArrow)){
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
      }

      // ← 방향키를 누를 때
      if(Input.GetKey(KeyCode.LeftArrow)){
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
      }

      //이동제한.
      Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
      viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
      viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
      Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
      transform.position = worldPos; //좌표를 적용한다.
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy")
        //부딪힌 객체의 태그를 비교해서 적인지 판단합니다.
        {
            //Debug.Log("주인공이 적과 충돌");
            //playerData.decreaseHP(10); // 체력 10 감소.
            PlayerData.HP -= 10;

            if (PlayerData.HP <= 0)
            {
                Destroy(this.gameObject);
            }

            //Destroy(this.gameObject);
            //자신을 파괴합니다.
        }
    }


}
