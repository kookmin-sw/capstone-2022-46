using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFoot : MonoBehaviour
{
    public GameObject bossFootPrefab;
    float time = 0.0f;

    
    // Update is called once per frame
    void Update()
    {
      //foot_anim.SetFloat("foot_speed",4);
      time += Time.deltaTime;

      if(time >= 4)
      {
          bossFootPrefab.SetActive(false);
          //++GameController.controller.removedGrenades;
          Debug.Log("Destroyed");
      }


    }


}
