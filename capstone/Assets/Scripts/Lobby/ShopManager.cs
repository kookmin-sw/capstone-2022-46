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
    }*///�׽�Ʈ������ ��ũ 100
    // Start is called before the first frame update
    public void UpgradePower()
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
            
        }
        

        Debug.Log("���� �Ŀ� " + PlayerPrefs.GetInt("Power"));
        Debug.Log("���� ���� " + PlayerPrefs.GetInt("Price1"));
    }

    public void UpgradeSpeed()
    {
        //Debug.Log("ȣ���� �ϴ°���?");
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
                PlayerPrefs.SetInt("Price2", PlayerPrefs.GetInt("Price2") + 1); // ���� ���
                Debug.Log("���� " + PlayerPrefs.GetInt("Price2") + "��ũ�� ���");
                PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 1); // ���׷��̵� ����
                Debug.Log("�̵��ӵ� " + PlayerPrefs.GetInt("Speed") + "�� ���");


            }

        }


        Debug.Log("���� �̵��ӵ� " + PlayerPrefs.GetInt("Speed"));
        Debug.Log("���� ���� " + PlayerPrefs.GetInt("Price2"));
    }

    public void UpgradeAtkSpd()
    {
        //Debug.Log("ȣ���� �ϴ°���?");
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
                PlayerPrefs.SetInt("Price3", PlayerPrefs.GetInt("Price3") + 1); // ���� ���
                Debug.Log("���� " + PlayerPrefs.GetInt("Price2") + "��ũ�� ���");
                PlayerPrefs.SetInt("AtkSpd", PlayerPrefs.GetInt("AtkSpd") + 1); // ���׷��̵� ����
                Debug.Log("���ݼӵ� " + PlayerPrefs.GetInt("Speed") + "�� ���");


            }

        }


        Debug.Log("���� �̵��ӵ� " + PlayerPrefs.GetInt("AtkSpd"));
        Debug.Log("���� ���� " + PlayerPrefs.GetInt("Price3"));
    }
    // Update is called once per frame
    void Update()
    {
        howManyInks.text = "����   ������: "+ PlayerPrefs.GetInt("Ink");//���� ��ȭ ������
        statText1.text = "���ݷ� 1 ����(" + PlayerPrefs.GetInt("Price1") + ")" +'\n' +  "(���� ���ݷ�: " + (int)(PlayerPrefs.GetInt("Power") + 10) + ")";//�⺻��ġ �׳� �ϵ��ڵ���
        statText2.text = "�̵��ӵ� 0.1 ����(" + PlayerPrefs.GetInt("Price2") + ")" + '\n' + "(���� �̵��ӵ�: " + (int)(PlayerPrefs.GetInt("Speed") + 3) + ")";//�⺻��ġ �׳� �ϵ��ڵ���
        statText3.text = "���ݼӵ� 10% ����(" + PlayerPrefs.GetInt("Price2") + ")" + '\n' + "(���� ���ݼӵ�: " /*+ (int)(PlayerPrefs.GetInt("AtkSpd") )*/ + ")";//�⺻��ġ ���� �����Ƽ� �ʱ���� �������� ��
    }
}
