using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public DialogueManager talkManager;
    public Image portraitImg;
    public Text talkText;
    public GameObject talkPanel;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Action(GameObject attach)
    {

      isAction = true;
      scanObject = attach;
      ObjData objData = scanObject.GetComponent<ObjData>();
      Talk(objData.id, objData.isNpc);

      talkPanel.SetActive(isAction);
    }


    void Talk(int id, bool isNpc)
    {
      string talkData = talkManager.GetTalk(id,talkIndex);

      if(talkData == null)
      {
        isAction = false;
        talkIndex = 0;
        return;
      }

      if(isNpc)
      {
        talkText.text = talkData;
        portraitImg.sprite = talkManager.GetPortrait(id);
        portraitImg.color = new Color(1,1,1,1);
      }
      else
      {
        talkText.text = talkData;
        portraitImg.color = new Color(1,1,1,0);
      }

       isAction = true;
       talkIndex++;

    }
}
