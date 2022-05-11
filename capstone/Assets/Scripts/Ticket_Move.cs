using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ticket_Move : MonoBehaviour
{
    public float Speed;
    public GameObject shopSet;
    

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
      float distanceX = Speed * Time.deltaTime;
      this.gameObject.transform.Translate(0, -1 * distanceX, 0);
  }

  void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

  private void OnTriggerEnter2D(Collider2D col) //적과 충돌
  {
      
      if (col.gameObject.tag == "Player")
      {
            //shopSet.SetActive(true);
            gameObject.SetActive(false);
                
        }

  }
}
