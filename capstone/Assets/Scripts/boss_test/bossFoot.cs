using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFoot : MonoBehaviour
{
    public GameObject bossFootPrefab;
    float time = 0.0f;
    public Animator animator;
    public Animation anim;

    // Update is called once per frame

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        //animator.SetFloat("foot_speed", 10f);
    }


    void Update()
    {

      //foot_anim.SetFloat("foot_speed",4);
      time += Time.deltaTime;


      if(time >= 3)
      {
          //animator.SetFloat("foot_speed", -3f);

          bossFootPrefab.SetActive(false);
          //++GameController.controller.removedGrenades;
          Debug.Log("Destroyed_foot");
      }

/*
      if(time >= 4)
      {
          animator.SetFloat("foot_speed", -3f);

          bossFootPrefab.SetActive(false);
          //++GameController.controller.removedGrenades;
          Debug.Log("Destroyed_foot");
      }
*/

    }

    public void setFootSpeed(float f_speed)
    {
      animator.SetFloat("foot_speed", f_speed);
      //float temp = f_speed.GetFloat("foot_speed");
      //f_speed.SetFloat("foot_speed", f_speed.GetFloat("foot_speed") + speed);
    }


}
