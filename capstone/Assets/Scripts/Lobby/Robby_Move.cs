using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robby_Move : MonoBehaviour
{
    public float speed;
    private Vector3 vector;
    public int walkCount;
    private int currentWalkCount;
    GameObject scanObject;

    public FloatingJoystick joy;

    private bool canMove = true;

    private Animator animator;

    public TextManager manager;
    //public SelectManager select;

    // BoxCollider 컴포넌트를 가져오기 위해 선언
    private BoxCollider2D boxCollider;

    // 통과불가능한 레이어를 설정해주기 위해 선언
    public LayerMask layerMask;

    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }

    IEnumerator MoveCoroutine()
    {


        // 키입력이 이뤄지는 동안 실행
        // 코루틴은 한번만 실행되고 입력이 이뤄지면 계속 실행
        while (x != 0 || y != 0)
        {
            if (manager.isAction == true || manager.isSelect == true)
            {
                break;
            }
            // 변수 vector의 값으로 입력한 방향키 값을 할당 -1 또는 1
            vector.Set(x, y, transform.position.z);

            // 입력한 vector 값을 받아 파라미터로 전달 -> 받은 파라미터를 기반으로 애니메이션 실행
            // 동시입력시에 상하키는 기본0이 되도록 설정
            if (vector.x != 0)
            {
                vector.y = 0;
            }
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);

            // A->B로 레이저를 쏴서 제대로 도착했을때 Null, 막혔을때 방해물이 Return
            RaycastHit2D hit;

            // A지점, 캐릭터의 현재 위치값
            Vector2 start = transform.position;
            // B지점, 캐릭터가 이동하고자 하는 위치값 (시작지점+이동값)
            Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);

            // 캐릭터에 BoxCollider가 적용되어 있어 그걸 충돌체로 인식하므로 해제 후 설정
            boxCollider.enabled = false;
            // 레이저 발사 (시작, 끝, 레이어마스크)
            hit = Physics2D.Linecast(start, end, layerMask);
            //hit = Physics2D.Raycast(start, end, 0.7f, layerMask);
            boxCollider.enabled = true;

            // 벽으로 막혔을때 실행하지 않게 처리
            if (hit.transform != null)
            {
                scanObject = hit.collider.gameObject;
                break;
            }
            else
            {
                scanObject = null;
            }


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
                    transform.Translate(0, vector.y * speed, 0);
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
        x = joy.Horizontal;
        y = joy.Vertical;
        if (x > y) // 입력값을 -1, 0, 1로 되도록
        {
            if (y > x * -1)
            {
                x = 1; y = 0;
            }
            else if (y < x * -1)
            {
                x = 0; y = -1;
            }
        }
        else if (y > x)
        {
            if (y > x * -1)
            {
                x = 0; y = 1;
            }
            else if (y < x * -1)
            {
                x = -1; y = 0;
            }
        }
        // 좌측 방향키면 -1, 우측 방향키면 1, 상측 방향키면 1, 하측 방향키면 -1
        // 버튼을 눌렀을 때 실행

        if (canMove)
        {
            if (x != 0 || y != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }

        if ((Input.GetButtonDown("Jump")) && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }
    public void clickedOn()
    {
        if (scanObject != null)
            manager.Action(scanObject);
    }
}
