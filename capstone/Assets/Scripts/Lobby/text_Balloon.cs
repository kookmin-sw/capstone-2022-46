using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_Balloon : MonoBehaviour {
    public Image readText;
    //public static GameTextControl instance;


    void Awake()
    {
        readText = GetComponent<Image>();
    }
    // Use this for initialization
    void Start()
    {
        readText.enabled = false;
        //readText.SetActive(false);
        StartCoroutine(ShowReady());
    }

    IEnumerator ShowReady()
    {
        //int count = 0;
        while (true)
        {
            //readText.SetActive(true);
            readText.enabled = true;
            yield return new WaitForSeconds(2f);
            //readText.SetActive(false);
            readText.enabled = false;
            yield return new WaitForSeconds(2f);
            //count++;
        }
        //count = 0;
    }
}
