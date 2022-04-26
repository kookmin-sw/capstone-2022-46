using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public Text talkText;
    public GameObject talkPanel;
    public GameObject scanObject;
    public bool isAction;

    public void Action(GameObject attach)
    {
      if(isAction)
      {
        isAction = false;
      }
      else
      {
        isAction = true;
        scanObject = attach;
        talkText.text = "이것의 이름은 "+ scanObject.name + "입니다.";

      }
      talkPanel.SetActive(isAction);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
