using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragile_Move : MonoBehaviour
{
  public float Speed;
  public int dir; //오른쪽은 1, 왼쪽은 -1
  public ObjectManager objectManager;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
      moveControl();
  }

  void moveControl()
  {
      float distanceY = Speed * Time.deltaTime;
      this.gameObject.transform.Translate(0, distanceY, 0);
  }

  void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

  private void OnTriggerEnter2D(Collider2D col) //적과 충돌
  {
      //Player playerLogic = player.GetComponent<Player>();
      if (col.gameObject.tag == "enemy")
      {
          gameObject.SetActive(false);
      }

  }
}
