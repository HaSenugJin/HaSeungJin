using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    private AsyncOperation asyncOperation;
    public Text text;
    public Text mess;

    IEnumerator Start()
    {
        //EditorApplication.isPaused = true;
        asyncOperation = SceneManager.LoadSceneAsync("Game Start");
        asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress * 100f;
            text.text = progress.ToString() + "%";
            yield return null;
            if (asyncOperation.progress > 0.7f)
            {
                //yield return new WaitForSeconds(2.5f);
                mess.gameObject.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                   print("??");
                   asyncOperation.allowSceneActivation = true;
                }
            }
        }
    }
}

