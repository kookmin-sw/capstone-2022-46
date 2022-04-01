using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float HP_MAX;

    Image hp_bar; //체력.

    public float lerpSpeed;
    public Text hp_Text;

    void Start()
    {
        hp_bar = GetComponent<Image>();
        HP_MAX = Player.health;
    }

    // Update is called once per frame
    void Update()
    {
        hp_bar.fillAmount = Mathf.Lerp(hp_bar.fillAmount, Player.health/HP_MAX, Time.deltaTime * lerpSpeed);
        hp_Text.text = Player.health + " / " + HP_MAX;
    }
}
