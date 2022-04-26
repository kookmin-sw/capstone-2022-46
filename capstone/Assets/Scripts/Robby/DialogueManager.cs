using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }


    void GenerateData()
    {
      talkData.Add(100, new string[] {"안녕하세요 작가님", "책속으로 오신것을 환영합니다."});
      talkData.Add(200, new string[] {"이곳은 상점입니다", "마음에 드는것을 골라보세요."});

      talkData.Add(10, new string[] {"평범한 책장이다."});
      talkData.Add(20, new string[] {"불이 꺼져있는 난로이다."});
      talkData.Add(30, new string[] {"단단한 벽이다."});
      talkData.Add(1, new string[] {"동화 안으로 이동 하시겠습니까?"});

      portraitData.Add(100, portraitArr[0]);
      portraitData.Add(200, portraitArr[1]);
    }

    public string GetTalk(int id, int talkIndex)
    {
      if(talkIndex == talkData[id].Length)
      {
        return null;
      }
      else
      {
        return talkData[id][talkIndex];
      }

    }


    public Sprite GetPortrait(int id)
    {
      return portraitData[id];
    }

}
