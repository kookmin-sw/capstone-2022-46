using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemy001Prefab;
    public GameObject enemy002Prefab;
    public GameObject bossSistersPrefab;
    public GameObject itemCoinPrefab;
    public GameObject itemRingPrefab;
    public GameObject itemTicketPrefab;
    public GameObject bulletPlayerPrefab;
    public GameObject bulletSistersPrefab;

    GameObject[] enemy001;
    GameObject[] enemy002;
    GameObject[] bossSisters;

    GameObject[] itemCoin;
    GameObject[] itemTicket;
    GameObject[] itemRing;

    GameObject[] bulletPlayer;
    GameObject[] bulletBossSisters;

    GameObject[] targetPool;
    // Start is called before the first frame update
    void Awake()
    {
        enemy001 = new GameObject[10];
        enemy002 = new GameObject[10];
        bossSisters = new GameObject[1];

        itemCoin = new GameObject[10];
        itemRing = new GameObject[3];
        //itemTicket = new GameObject[1];

        bulletPlayer = new GameObject[20];
        bulletBossSisters = new GameObject[50];

        Genarate();
    }

    void Genarate()
    {
        for (int index = 0; index < enemy001.Length; index++)
        {
            enemy001[index] = Instantiate(enemy001Prefab);
            enemy001[index].SetActive(false);
        }

        for (int index = 0; index < enemy002.Length; index++)
        {
            enemy002[index] = Instantiate(enemy002Prefab);
            enemy002[index].SetActive(false);
        }
        for (int index = 0; index < bossSisters.Length; index++)
        {
            bossSisters[index] = Instantiate(bossSistersPrefab);
            bossSisters[index].SetActive(false);
        }

        for (int index = 0; index < itemCoin.Length; index++)
        {
            itemCoin[index] = Instantiate(itemCoinPrefab);
            itemCoin[index].SetActive(false);
        }

        for (int index = 0; index < itemRing.Length; index++)
        {
            itemRing[index] = Instantiate(itemRingPrefab);
            itemRing[index].SetActive(false);
        }

        for (int index = 0; index < bulletPlayer.Length; index++)
        {
            bulletPlayer[index] = Instantiate(bulletPlayerPrefab);
            bulletPlayer[index].SetActive(false);
        }

        for (int index = 0; index < bulletBossSisters.Length; index++)
        {
            bulletBossSisters[index] = Instantiate(bulletSistersPrefab);
            bulletBossSisters[index].SetActive(false);
        }

    }
    public GameObject MakeObj(string type)
    {

        switch (type)
        {
            case "enemy001":
                targetPool = enemy001;
                break;
            case "enemy002":
                targetPool = enemy002;
                break;
            case "bossSisters":
                targetPool = bossSisters;
                break;
            case "itemCoin":
                targetPool = itemCoin;
                break;
            case "itemRing":
                targetPool = itemRing;
                break;
            case "bulletPlayer":
                targetPool = bulletPlayer;
                break;
            case "bulletBossSisters":
                targetPool = bulletBossSisters;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }

        return null;
    }

    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "enemy001":
                targetPool = enemy001;
                break;
            case "enemy002":
                targetPool = enemy002;
                break;
            case "bossSisters":
                targetPool = bossSisters;
                break;
            case "itemCoin":
                targetPool = itemCoin;
                break;
            case "itemRing":
                targetPool = itemRing;
                break;
            case "bulletPlayer":
                targetPool = bulletPlayer;
                break;
            case "bulletBossSisters":
                targetPool = bulletBossSisters;
                break;
        }
        return targetPool;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
