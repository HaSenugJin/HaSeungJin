using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SiderbarController : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycbwzwFulNGZgzlmNtrusrmJdqrOzs0eWIGhOGgYeYZKahT_GGACWDkZustH8vtwkDYYzKg/exec";
    public GameObject sidebar;
    private Animator An;

    private void Awake()
    {
        An = sidebar.GetComponent<Animator>();
    }

    private void Update()
    {
        if (ControllerManager.GetInstance().loss)
        {
            An.SetBool("Move", ControllerManager.GetInstance().loss);
        }
    }

    public void On()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "setmoeny");
        form.AddField("moeny", ControllerManager.GetInstance().moeny);
        StartCoroutine(moeny(form));
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("GameManager"));
    }

    IEnumerator moeny(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            www.Dispose();
        }
    }
}
