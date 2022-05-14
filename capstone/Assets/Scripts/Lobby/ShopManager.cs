using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    
   
    public Text statText1;
    public Text statText2;
    public Text statText3;
    public Text howManyInks;
    /*private void Start()
    {
        fortest();
    }
    public void fortest()
    {
        PlayerPrefs.SetInt("Ink", 100);
    }*///테스트용으로 잉크 100
    // Start is called before the first frame update
    public void UpgradePower()
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
            
        }
        

        Debug.Log("현재 파워 " + PlayerPrefs.GetInt("Power"));
        Debug.Log("현재 가격 " + PlayerPrefs.GetInt("Price1"));
    }

    public void UpgradeSpeed()
    {
        //Debug.Log("호출은 하는거지?");
        if (!PlayerPrefs.HasKey("Speed"))
        {
            PlayerPrefs.SetInt("Speed", 0);
        }
        if (!PlayerPrefs.HasKey("Price2"))
            PlayerPrefs.SetInt("Price2", 1);
        if (PlayerPrefs.HasKey("Ink"))
        {

            if (PlayerPrefs.GetInt("Ink") >= PlayerPrefs.GetInt("Price2"))
            {
                PlayerPrefs.SetInt("Ink", PlayerPrefs.GetInt("Ink") - PlayerPrefs.GetInt("Price2"));
                PlayerPrefs.SetInt("Price2", PlayerPrefs.GetInt("Price2") + 1); // 가격 상승
                Debug.Log("가격 " + PlayerPrefs.GetInt("Price2") + "잉크로 상승");
                PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 1); // 업그레이드 적용
                Debug.Log("이동속도 " + PlayerPrefs.GetInt("Speed") + "로 상승");


            }

        }


        Debug.Log("현재 이동속도 " + PlayerPrefs.GetInt("Speed"));
        Debug.Log("현재 가격 " + PlayerPrefs.GetInt("Price2"));
    }

    public void UpgradeAtkSpd()
    {
        //Debug.Log("호출은 하는거지?");
        if (!PlayerPrefs.HasKey("AtkSpd"))
        {
            PlayerPrefs.SetInt("AtkSpd", 0);
        }
        if (!PlayerPrefs.HasKey("Price3"))
            PlayerPrefs.SetInt("Price3", 1);
        if (PlayerPrefs.HasKey("Ink"))
        {

            if (PlayerPrefs.GetInt("Ink") >= PlayerPrefs.GetInt("Price3"))
            {
                PlayerPrefs.SetInt("Ink", PlayerPrefs.GetInt("Ink") - PlayerPrefs.GetInt("Price3"));
                PlayerPrefs.SetInt("Price3", PlayerPrefs.GetInt("Price3") + 1); // 가격 상승
                Debug.Log("가격 " + PlayerPrefs.GetInt("Price2") + "잉크로 상승");
                PlayerPrefs.SetInt("AtkSpd", PlayerPrefs.GetInt("AtkSpd") + 1); // 업그레이드 적용
                Debug.Log("공격속도 " + PlayerPrefs.GetInt("Speed") + "로 상승");


            }

        }


        Debug.Log("현재 이동속도 " + PlayerPrefs.GetInt("AtkSpd"));
        Debug.Log("현재 가격 " + PlayerPrefs.GetInt("Price3"));
    }
    // Update is called once per frame
    void Update()
    {
        howManyInks.text = "현재   보유량: "+ PlayerPrefs.GetInt("Ink");//현재 재화 보유량
        statText1.text = "공격력 1 증가(" + PlayerPrefs.GetInt("Price1") + ")" +'\n' +  "(현재 공격력: " + (int)(PlayerPrefs.GetInt("Power") + 10) + ")";//기본수치 그냥 하드코딩함
        statText2.text = "이동속도 0.1 증가(" + PlayerPrefs.GetInt("Price2") + ")" + '\n' + "(현재 이동속도: " + (int)(PlayerPrefs.GetInt("Speed") + 3) + ")";//기본수치 그냥 하드코딩함
        statText3.text = "공격속도 10% 증가(" + PlayerPrefs.GetInt("Price2") + ")" + '\n' + "(현재 공격속도: " /*+ (int)(PlayerPrefs.GetInt("AtkSpd") )*/ + ")";//기본수치 수정 귀찮아서 초기공속 정해지면 함
    }
}
