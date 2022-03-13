using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float Speed = 3f;

    // Update is called once per frame
    void Update()
    {
        Move();
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
    }
}
