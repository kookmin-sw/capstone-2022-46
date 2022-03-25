using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : IEnumerable, System.IDisposable
{
  //아이템 클래스
  class Item
  {
    public bool active; // 오브젝트가 사용하고 있는 중인지 판단하는 변수
    public GameObject gameObject; // 저장할 오브젝트
  }

  //아이템 클래스 배열선언
  Item[] table;

  //열거자 재정의
  public IEnumerator GetEnumerator()
  {
    // 만약 table이 객체화 되지 않았다면?
    if (table == null) {yield break;} // 함수를 그냥 탈출

    // table이 존재하면 여기서부터 실행 /
    int count = table.Length;

    // 총 count만큼 반복
    for (int i = 0; i < count; i++)
    {
      Item item = table[i];
      // item에 table의 i위치에 해당되는 객체를 대입
      if (item.active) //아이탬 사용중이면
      {
        yield return item.gameObject; // 현 item의 오브젝트를 반환
      }
    }

  }



  //메모리 풀 생성
  //original : 미리생성 원본
  // count : 풀 최고갯수

  public void Create(Object original, int count)
  {
    Dispose(); // 메모리풀 초기화
    table = new Item[count]; // count 만큼 배열을 생성

    for (int i = 0; i < count; i++) // count 만큼 반복
    {
      Item item = new Item();
      item.active = false;
      item.gameObject = GameObject.Instantiate(original) as GameObject;
      // original을 GameObject 형식으로 item.gameObject에 저장
      item.gameObject.SetActive(false);
      // SetActive는 활성화 함수인데 메모리에만 올릴 것이므로 비활성화 상태로 저장
      table[i] = item;
    }

  }

  //새 아이템 요청
  public GameObject NewItem()
  {
    if (table == null) {return null;}
    int count = table.Length;

    for (int i = 0; i < count; i++)
    {
      Item item = table[i];
      if (item.active == false)
      {
        item.active = true;
        item.gameObject.SetActive(true);
        return item.gameObject;
      }
    }

    return null;
  }


  // 아이템 사용종료
  // gameObject : NewItem으로 가져온 객체
  public void RemoveItem(GameObject gameObject)
  {
    // table이 객체화되지 않았거나, 매개변수로 오는 gameObject가 없다면 함수 탈출
    if (table == null || gameObject == null) {return;}

    // table이 존재하거나, 매개변수로 오는 gameObject가 존재하면 여기서부터 실행
    int count = table.Length;

    for (int i = 0; i < count; i++)
    {
      Item item = table[i];
      // 매개변수 gameObject와 item의 gameObject가 같다면
      if (item.gameObject == gameObject)
      {
        // active 변수를 false로
        item.active = false;
        // 그리고 게임오브젝트를 비활성화 시킨다.
        item.gameObject.SetActive(false);
        break;
      }
    }

  }



    // 모든 아이템 사용종료
    public void ClearItem()
    {
      // table이 객체화되지 않았은경우
      if (table == null) {return;}

      // table이 존재하면
      int count = table.Length;

      for (int i = 0; i < count; i++)
      {
        Item item = table[i];

        // item이 비어있지 않고, 활성화되어 있다면
        if (item != null && item.active)
        {
          // 비활성화 처리를 시작합니다.
          item.active = false;
          item.gameObject.SetActive(false);
        }
      }

    }


    public void Dispose()
    {
      // table이 객체화되지 않았다면..
      if (table == null) {return;}
      // table이 존재하면
      int count = table.Length;

      for (int i = 0; i < count; i++)
      {
        Item item = table[i];
        GameObject.Destroy(item.gameObject);
        // 메모리 풀을 삭제하는 것이기 때문에 모든 오브젝트를 Destroy 한다.
      }

      table = null;

    }




}
