using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MemberForm
{
    public int index;
    public string name;
    public int age;
    public int gender;

    public MemberForm(int index, string name, int age, int gender)
    {
        this.index = index;
        this.name = name;
        this.age = age;
        this.gender = gender;
    }
}

public class ExampleManager : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbwzwFulNGZgzlmNtrusrmJdqrOzs0eWIGhOGgYeYZKahT_GGACWDkZustH8vtwkDYYzKg/exec";

    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("value", "값");
        UnityWebRequest www = UnityWebRequest.Post(URL,form);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        print(data);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("ProgressScene");
    }
}

/*
//요청을 하기위한 작업
UnityWebRequest request = UnityWebRequest.Get(URL);

MemberForm member = new MemberForm("ddt", 44, 2);

WWWForm from = new WWWForm();

//from.AddField(nameof(member.index), member.index);
from.AddField("name", member.name);
from.AddField("age", member.age);
from.AddField("gender", member.gender);

yield return request.SendWebRequest();
*/

/*
using (UnityWebRequest request = UnityWebRequest.Get(URL))
{
    MemberForm json = JsonUtility.FromJson<MemberForm>(request.downloadHandler.text);
    yield return request.SendWebRequest();
    //응답에 대한 작업
    print(json.index);
    print(json.name);
    print(json.age);
    print(json.gender);
}
*/