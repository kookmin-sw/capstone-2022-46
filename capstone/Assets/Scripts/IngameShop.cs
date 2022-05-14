                    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameShop : MonoBehaviour
{
    public GameObject player;
    public GameObject coin;

    int price1;
    public Text priceText1;
    public Text statText1;
    int price2;
    public Text priceText2;
    public Text statText2;
    int price3;
    public Text priceText3;
    public Text statText3;


    // Start is called before the first frame update
    void Start()
    {
        price1 = 1;
        price2 = 1;
        price3 = 1;
        priceText1.text = "+10%(1���)";
        priceText2.text = "+10%(1���)";
        priceText3.text = "+10%(1���)";
        Player playerData = player.GetComponent<Player>();
        statText1.text = "���� ���ݷ�: " + (int)playerData.dmg;
        statText2.text = "���� �̵��ӵ�: " + (int)playerData.Speed;
        statText3.text = "���� ���ݼӵ�: " + (int)(1 / playerData.maxShotDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PurchasePower()
    {
        Player playerData = player.GetComponent<Player>();
        GoldState scoreData = coin.GetComponent<GoldState>();
        if (scoreData.score >= price1)
        {
            scoreData.score -= price1;
            price1++;
            priceText1.text = "+10%(" + price1 + "���)";
            playerData.dmg = playerData.dmg * (float)(1.1);//�Ŀ���
            statText1.text = "���� ���ݷ�: " + (int)playerData.dmg;
            Debug.Log("���� ���ݷ�: " + playerData.dmg);
        }
        else Debug.Log("���� ����");
    }

    public void PurchaseSpeed()
    {
        Player playerData = player.GetComponent<Player>();
        GoldState scoreData = coin.GetComponent<GoldState>();
        if (scoreData.score >= price2)
        {
            scoreData.score -= price2;
            price2++;
            priceText2.text = "+10%(" + price2 + "���)";
            playerData.Speed = playerData.Speed * (float)(1.1);//���ǵ��
            statText2.text = "���� �̵��ӵ�: " + (int)playerData.Speed;
            Debug.Log("���� �̵��ӵ�: " + playerData.Speed);
        }
        else Debug.Log("���� ����");
    }
    public void PurchaseAtkSpd()
    {
        Player playerData = player.GetComponent<Player>();
        GoldState scoreData = coin.GetComponent<GoldState>();
        if (scoreData.score >= price3)
        {
            scoreData.score -= price3;
            price3++;
            priceText3.text = "+10%(" + price3 + "���)";
            playerData.maxShotDelay = playerData.maxShotDelay * (float)(0.9);//���ݼӵ���
            statText3.text = "���� ���ݼӵ�: " + (int)(1/playerData.maxShotDelay);
            Debug.Log("���� ���ݼӵ�: " + playerData.maxShotDelay);
        }
        else Debug.Log("���� ����");
    }
   
}
