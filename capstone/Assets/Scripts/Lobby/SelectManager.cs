using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SelectManager : MonoBehaviour
{
  //public bool isSelect = true;
  public TextManager manager;

  public void exit_Portal()
  {
    GameObject.Find("Canvas").transform.Find("portal").gameObject.SetActive(false);
    EventSystem.current.SetSelectedGameObject(null);

    manager.isSelect = false;
  }

  public void active_Portal()
  {
    SceneManager.LoadScene("MainGame");
  }

  public void exit_Shop()
  {
    GameObject.Find("Canvas").transform.Find("shop").gameObject.SetActive(false);
    EventSystem.current.SetSelectedGameObject(null);

    manager.isSelect = false;
  }
}
