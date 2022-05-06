using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameShop : MonoBehaviour
{

    public GameObject player;

    int price1;

    // Start is called before the first frame update
    void Start()
    {
        price1 = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Purchase()
    {
        Player playerData = player.GetComponent<Player>();
        if (playerData.money >= price1)
        {
            playerData.money -= price1;
            price1++;
            PowerUp();
            Debug.Log("µ¥¹ÌÁö »ó½Â");
        }
        else Debug.Log("µ·ÀÌ ¾øÀ½");
    }

    void PowerUp()
    {
        Player playerData = player.GetComponent<Player>();
        playerData.dmg++;
    }

}
