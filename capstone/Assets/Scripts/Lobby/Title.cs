using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string sceneName = "Game_Lobby";

    public void ClickStart()
    {
        Debug.Log("로딩");
        //SceneManager.LoadScene(sceneName);
        Loading.LoadScene("Game_Lobby");
    }

    public void ClickLoad()
    {
        Debug.Log("로드");
    }

    public void ClickExit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    public void PortalStart()
    {
      Debug.Log("인게임 들어감");
      //SceneManager.LoadScene(sceneName);
      Loading.LoadScene("MainGame");
    }
}
