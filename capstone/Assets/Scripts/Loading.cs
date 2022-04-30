using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
  public static string nextScene;
  private bool canOpen = true;


  private void Start()
  {
      StartCoroutine(LoadScene());
  }

  string nextSceneName;
  public static void LoadScene(string sceneName)
  {
      nextScene = sceneName;
      SceneManager.LoadScene("Loading");
  }


  IEnumerator LoadScene()
  {
      yield return null;

      AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
      op.allowSceneActivation = false;
      yield return new WaitForSeconds(2.0f);

      while(!op.isDone)
      {
        //yield return new WaitForSeconds(2.0f);

        yield return true;

        if(canOpen)
        {
          op.allowSceneActivation = true;
        }

      }



  }
}
