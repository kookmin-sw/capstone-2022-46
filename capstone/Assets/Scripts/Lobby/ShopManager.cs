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
        //Debug.Log("ȣ���� �ϴ°���?");
        if (!PlayerPrefs.HasKey("Power")) { 
            PlayerPrefs.SetInt("Power", 0);}
        if (!PlayerPrefs.HasKey("Price1"))
            PlayerPrefs.SetInt("Price1", 1);
        if (PlayerPrefs.HasKey("Ink"))
        {

            if (PlayerPrefs.GetInt("Ink") >= PlayerPrefs.GetInt("Price1"))
            {
                PlayerPrefs.SetInt("Ink", PlayerPrefs.GetInt("Ink") - PlayerPrefs.GetInt("Price1"));
                PlayerPrefs.SetInt("Price1", PlayerPrefs.GetInt("Price1") + 1); // ���� ���
                Debug.Log("���� " + PlayerPrefs.GetInt("Price1") + "��ũ�� ���");
                PlayerPrefs.SetInt("Power", PlayerPrefs.GetInt("Power") + 1); // ���׷��̵� ����
                Debug.Log("�Ŀ� " + PlayerPrefs.GetInt("Power") + "�� ���");

                

            }
            else Debug.Log("��ũ�� �����մϴ�");
        }
        

        Debug.Log("���� �Ŀ� " + PlayerPrefs.GetInt("Power"));
        Debug.Log("���� ���� " + PlayerPrefs.GetInt("Price1"));
    }
    
    // Update is called once per frame
    void Update()
    {
        statText1.text = "���ݷ� ����(" + PlayerPrefs.GetInt("Price1") + ") (���� ���ݷ�: " + (int)(PlayerPrefs.GetInt("Power") + 10) + ")";//�⺻���ݷ� �׳� �ϵ��ڵ���
    }
}
