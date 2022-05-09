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


    // Start is called before the first frame update
    void Start()
    {
        price1 = 1; //현재 공격력도 보여주고 이미지로 좀 더 
        priceText1.text = "+10%(1골드)";
        Player playerData = player.GetComponent<Player>();
        statText1.text = "현재 공격력: " + (int)playerData.dmg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Purchase()
    {
        Player playerData = player.GetComponent<Player>();
        GoldState scoreData = coin.GetComponent<GoldState>();
        if (scoreData.score >= price1)
        {
            scoreData.score -= price1;
            price1++;
            priceText1.text = "+10%("+price1+"골드)";
            PowerUp();
            statText1.text = "현재 공격력: " + (int)playerData.dmg;
            Debug.Log("현재 공격력: " + playerData.dmg);
        }
        else Debug.Log("돈이 없음");
    }

    void PowerUp()
    {
        Player playerData = player.GetComponent<Player>();
        playerData.dmg = playerData.dmg * (float)(1.1);
    }

}
