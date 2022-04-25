using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robby_Move : MonoBehaviour
{
    public float speed;
    private Vector3 vector;



    public int walkCount;
    private int currentWalkCount;

    private bool canMove = true;

      private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator MoveCoroutine()
      {

          // 키입력이 이뤄지는 동안 실행
          // 코루틴은 한번만 실행되고 입력이 이뤄지면 계속 실행
          while (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") !=0)
          {
              // Shift키 입력을 확인하여 스피드 값 할당, 입력 여부를 반환


              // 변수 vector의 값으로 입력한 방향키 값을 할당 -1 또는 1
              vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

              // 입력한 vector 값을 받아 파라미터로 전달 -> 받은 파라미터를 기반으로 애니메이션 실행
              // 동시입력시에 상하키는 기본0이 되도록 설정
              if (vector.x != 0)
              {
                  vector.y = 0;
              }
              animator.SetFloat("DirX", vector.x);
              animator.SetFloat("DirY", vector.y);
              animator.SetBool("Walking", true);


              // walkCount 값만큼 반복하여 객체 이동 walkCount(20) * speed(2.4) = 48px
              // 이동시 Shift키 입력여부 확인하여 Speed 값 추가(2.4)
              while (currentWalkCount < walkCount)
              {
                  if (vector.x != 0)
                  {
                      transform.Translate(vector.x * speed, 0, 0);
                  }
                  else if (vector.y != 0)
                  {
                      transform.Translate(0, vector.y * speed , 0);
                  }


                  currentWalkCount++;

                  // 0.01f의 대기시간을 가지고 while문을 반복
                  yield return new WaitForSeconds(0.01f);
              }

              // 변수 리셋
              currentWalkCount = 0;
          }
          canMove = true;

          // Walking 값 리셋
          animator.SetBool("Walking", false);


      }

    // Update is called once per frame
    void Update()
    {
        // 좌측 방향키면 -1, 우측 방향키면 1, 상측 방향키면 1, 하측 방향키면 -1
        // 버튼을 눌렀을 때 실행

        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }
    }
}
