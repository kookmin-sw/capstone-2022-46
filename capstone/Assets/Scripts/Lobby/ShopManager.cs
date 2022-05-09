using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    
    public Text priceText1;
    public Text statText1;
    

    // Start is called before the first frame update
    public void Upgrade()
    {
        //Debug.Log("호출은 하는거지?");
        if (!PlayerPrefs.HasKey("Power")) { 
            PlayerPrefs.SetInt("Power", 0);}
        if (!PlayerPrefs.HasKey("Price1"))
            PlayerPrefs.SetInt("Price1", 1);
        if (PlayerPrefs.HasKey("Ink"))
        {

            if (PlayerPrefs.GetInt("Ink") >= PlayerPrefs.GetInt("Price1"))
            {
                PlayerPrefs.SetInt("Ink", PlayerPrefs.GetInt("Ink") - PlayerPrefs.GetInt("Price1"));
                PlayerPrefs.SetInt("Price1", PlayerPrefs.GetInt("Price1") + 1); // 가격 상승
                Debug.Log("가격 " + PlayerPrefs.GetInt("Price1") + "잉크로 상승");
                PlayerPrefs.SetInt("Power", PlayerPrefs.GetInt("Power") + 1); // 업그레이드 적용
                Debug.Log("파워 " + PlayerPrefs.GetInt("Power") + "로 상승");

                

            }
            else Debug.Log("잉크가 부족합니다");
        }
        

        Debug.Log("현재 파워 " + PlayerPrefs.GetInt("Power"));
        Debug.Log("현재 가격 " + PlayerPrefs.GetInt("Price1"));
    }
    
    // Update is called once per frame
    void Update()
    {
        statText1.text = "공격력 증가(" + PlayerPrefs.GetInt("Price1") + ") (현재 공격력: " + (int)(PlayerPrefs.GetInt("Power") + 10) + ")";//기본공격력 그냥 하드코딩함
    }
}
