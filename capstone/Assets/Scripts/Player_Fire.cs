using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour
{
  public GameObject PlayerMissile; // 복제할 미사일 오브젝트
  public Transform MissileLocation; // 미사일이 발사될 위치
  public float FireDelay; // 미사일 발사 속도(미사일이 날라가는 속도x)
  private bool FireState; // 미사일 발사 속도를 제어할 변수




    // Start is called before the first frame update
    void Start()
    {
      // 처음에 미사일을 발사할 수 있도록 제어변수를 true로 설정
      FireState = true;
    }

    // Update is called once per frame
    void Update()
    {
      // 매 프레임마다 미사일발사 함수를 체크한다.
      playerFire();
    }

    private void playerFire(){
      //제어변수가 true일때만 작동
      if(FireState){
        //키보드 스페이스 누를때
        if(Input.GetKey(KeyCode.Space)){
          //코루틴 FireCycleControl 실행
          StartCoroutine(FireCycleControl());

          // "PlayerMissile"을 "MissileLocation"의 위치에 "MissileLocation"의 방향으로 복제한다
          Instantiate(PlayerMissile, MissileLocation.position, MissileLocation.rotation);
        }
      }
    }

    //코루틴 함수
    IEnumerator FireCycleControl() {
      // 처음에 FireState를 false로 만들고
      FireState = false;
      // FireDelay초 후에
      yield return new WaitForSeconds(FireDelay);
      // FireState를 true로 만든다.
      FireState = true;
    }



}
