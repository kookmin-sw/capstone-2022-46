using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFoot : MonoBehaviour
{
    public GameObject bossFootPrefab;
    float time = 0.0f;
    public Animator f_speed;

    // Update is called once per frame

    void Awake()
    {
        f_speed = GetComponent<Animator>();
    }


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

    public void setFootSpeed(float speed)
    {
      //float temp = f_speed.GetFloat("foot_speed");
      f_speed.SetFloat("foot_speed", f_speed.GetFloat("foot_speed") + speed);
    }


}
