using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/*
[System.Serializable]
public class me
{
    public int money;
}
*/

public class ButtonController : MonoBehaviour
{
    //const string URL = "https://script.google.com/macros/s/AKfycbwzwFulNGZgzlmNtrusrmJdqrOzs0eWIGhOGgYeYZKahT_GGACWDkZustH8vtwkDYYzKg/exec";
    //public me me2;
    public void GameStart()
    {
        ControllerManager.GetInstance();
        //UnityWebRequest request = UnityWebRequest.Get(URL);
        //MemberForm json = JsonUtility.FromJson<MemberForm>(request.downloadHandler.text);
        
        /*
        WWWForm form = new WWWForm();
        //form.AddField("order", "getmoeny");
        //print(json.money);
        ControllerManager.GetInstance().moeny = 0;
        //StartCoroutine(moeny(form));
        ControllerManager.GetInstance().GameIsPaused = false;
        ControllerManager.GetInstance().boom = false;
        ControllerManager.GetInstance().loss = false;
        ControllerManager.GetInstance().Win = false;
        ControllerManager.GetInstance().Idle = true;
        ControllerManager.GetInstance().BulletSpeed = 10.0f;
        ControllerManager.GetInstance().PlayerBulletDmg = 1.0f;
        ControllerManager.GetInstance().player_HP = 20.0f;
        ControllerManager.GetInstance().PlayerSpeed = 6.0f;
        ControllerManager.GetInstance().EnemyKill = 0;
        ControllerManager.GetInstance().WHP = 80.0f;
        ControllerManager.GetInstance().UHP = 150.0f;
        ControllerManager.GetInstance().EnemyHP = 8.0f;
        */
        SceneManager.LoadScene("Game Start");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    /*
    IEnumerator moeny(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            www.Dispose();
        }
    }
    */
}
