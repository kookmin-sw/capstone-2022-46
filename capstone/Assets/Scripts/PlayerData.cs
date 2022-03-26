using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
  private int HP; // 체력
  private int HP_MAX;

/*
  private Image hp_bar; //체력바

  [SerializeField]
  private float lerpSpeed;
  */

  //생성자.
  public PlayerData(int hp){
    HP = hp;
    HP_MAX = hp;
  }

  //setter
  public void setHP(int hp){
    HP = hp;
    HP_MAX = hp;
  }

  //damage만큼 체력 빼기.
  public void decreaseHP(int damage){
    HP -= damage;
    Debug.Log("주인공 체력감소");
  }

  public int getHP(){
    return HP;
  }



/*
  void Start()
  {
    hp_bar = GetComponent<Image>();
  }

  void Update()
  {
    if( (HP/HP_MAX) != hp_bar.fillAmount )
    {
      hp_bar.fillAmount = Mathf.Lerp(hp_bar.fillAmount, HP/HP_MAX, Time.deltaTime * lerpSpeed );
    }
  }
*/

}
