using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private int HP; // 적 체력

    //생성자.
    public EnemyData(int hp){
      HP = hp;
    }

    //setter
    public void setHP(int hp){
      HP = hp;
    }

    //damage만큼 체력 빼기.
    public void decreaseHP(int damage){
      HP -= damage;
    }

    public int getHP(){
      return HP;
    }

}
