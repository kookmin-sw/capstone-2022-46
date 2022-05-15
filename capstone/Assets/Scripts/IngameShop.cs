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
        priceText1.text = "+10%(1골드)";
        priceText2.text = "+10%(1골드)";
        priceText3.text = "+10%(1골드)";
        //Player playerData = player.GetComponent<Player>();
        statText1.text = "현재 공격력: " + (int)Player.instance.dmg;
        statText2.text = "현재 이동속도: " + (int)Player.instance.Speed;
        statText3.text = "현재 공격속도: " + (int)Player.instance.maxShotDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //Player playerData = player.GetComponent<Player>();
        statText1.text = "현재 공격력: " + (int)Player.instance.dmg;
        statText2.text = "현재 이동속도: " + (int)Player.instance.Speed;
        statText3.text = "현재 공격속도: " + (int)Player.instance.maxShotDelay;
    }
    public void PurchasePower()
    {
        //Player playerData = player.GetComponent<Player>();
        GoldState scoreData = coin.GetComponent<GoldState>();
        if (scoreData.score >= price1)
        {
            scoreData.score -= price1;
            price1++;
            priceText1.text = "+10%(" + price1 + "����)";
            Player.instance.dmg = Player.instance.dmg * (float)(1.1);//파워업
            statText1.text = "현재 공격력: " + (int)Player.instance.dmg;
            Debug.Log("현재 공격력: " + Player.instance.dmg);
        }
        else Debug.Log("골드 부족!");
    }

    public void PurchaseSpeed()
    {
        //Player playerData = player.GetComponent<Player>();
        GoldState scoreData = coin.GetComponent<GoldState>();
        if (scoreData.score >= price2)
        {
            scoreData.score -= price2;
            price2++;
            priceText2.text = "+10%(" + price2 + "골드)";
            Player.instance.Speed = Player.instance.Speed * (float)(1.1);//스피드업
            statText2.text = "현재 이동속도: " + (int)Player.instance.Speed;
            Debug.Log("현재 이동속도: " + Player.instance.Speed);
        }
        else Debug.Log("골드 부족!");
    }
    public void PurchaseAtkSpd()
    {
        //Player playerData = player.GetComponent<Player>();
        GoldState scoreData = coin.GetComponent<GoldState>();
        if (scoreData.score >= price3)
        {
            scoreData.score -= price3;
            price3++;
            priceText3.text = "+10%(" + price3 + "골드)";
            Player.instance.maxShotDelay = Player.instance.maxShotDelay * (float)(1.1);//공속 업
            statText3.text = "현재 공격속도: " + (int)(Player.instance.maxShotDelay);
            Debug.Log("현재 공격속도: " + Player.instance.maxShotDelay);
        }
        else Debug.Log("골드 부족!");
    }

}
