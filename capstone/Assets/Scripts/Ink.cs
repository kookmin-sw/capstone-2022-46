using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceY = 2 * Time.deltaTime;
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!PlayerPrefs.HasKey("Ink"))
            {
                PlayerPrefs.SetInt("Ink", 1);
                Debug.Log("��ũ ���� 1");
            }
            else {
                PlayerPrefs.SetInt("Ink", PlayerPrefs.GetInt("Ink") + 1);
                Debug.Log("��ũ ���� " + PlayerPrefs.GetInt("Ink"));
            }//�̰� �⺻ ���ø�, �̰� ���� �����ؾ� �� �����͸� �����ϸ� ��
            PlayerPrefs.Save();
            gameObject.SetActive(false);
        }

    }
}
