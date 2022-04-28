using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
  //public bool isSelect = true;
  public TextManager manager;

  public void exit_Portal()
  {
    GameObject.Find("Canvas").transform.Find("portal").gameObject.SetActive(false);
    //isSelect = false;
    manager.isSelect = false;
  }

  public void active_Portal()
  {
    SceneManager.LoadScene("MainGame");
  }
}
