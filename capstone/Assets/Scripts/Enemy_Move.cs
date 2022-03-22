using UnityEngine;
using System.Collections;

public class Enemy_Move : MonoBehaviour {
    public float moveSpeed = 2.3f;
    //상수로 움직일 속도를 지정
    void Start () {

    }
    void Update () {
        moveControl();
        //프레임이 변화할때 마다 움직임을 관리해주는 함수를 호출
    }
    void moveControl()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        //움직일 거리를 계산
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
        //움직임을 반영합니다.
    }
}
