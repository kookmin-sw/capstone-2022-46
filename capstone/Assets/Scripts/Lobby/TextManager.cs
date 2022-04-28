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

    public bool isSelect;

    //public SelectManager selectManager;



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

        if(id == 1 )
        {
          //selectManager.activePortal();
          GameObject.Find("Canvas").transform.Find("portal").gameObject.SetActive(true);
          isSelect = true;
          Debug.Log("들어왔음");
          //return;
        }



        isAction = false;
        talkIndex = 0;
        return;
      }

      if(isNpc)
      {
        talkText.text = talkData;
        portraitImg.sprite = talkManager.GetPortrait(id);
        portraitImg.color = new Color(1,1,1,1);
        //GameObject.Find("Canvas").transform.Find("test").gameObject.SetActive(true);
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
