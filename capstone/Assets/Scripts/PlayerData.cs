using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
  public static float HP; // 체력
  public float HP_MAX ;


  Image hp_bar; //체력바

  [SerializeField]
  private float lerpSpeed;

  public Text hp_Text;


  //생성자.
  public PlayerData(float hp){
    HP = hp;
    HP_MAX = hp;
  }

  //setter
  public void setHP(float hp){
    HP = hp;
    HP_MAX = hp;
  }

  //damage만큼 체력 빼기.
  public void decreaseHP(float damage){
    HP -= damage;
    Debug.Log("주인공 체력감소");
  }

  public float getHP(){
    return HP;
  }


  void Start()
  {
    hp_bar = GetComponent<Image>();
    HP = HP_MAX;
  }

  void Update()
  {
    hp_bar.fillAmount = Mathf.Lerp(hp_bar.fillAmount, HP/HP_MAX, Time.deltaTime * lerpSpeed);
    hp_Text.text = HP + " / " + HP_MAX;
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
