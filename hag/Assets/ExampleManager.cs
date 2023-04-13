using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class MemberForm
{
    //public int index;
    public string order,result,msg,value;
}

public class ExampleManager : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbwzwFulNGZgzlmNtrusrmJdqrOzs0eWIGhOGgYeYZKahT_GGACWDkZustH8vtwkDYYzKg/exec";
    public MemberForm me;
    public InputField IDInput, PassInput;
    string id, pass;
    
    bool SetIDPass()
    {
        id = IDInput.text.Trim();
        pass = PassInput.text.Trim();

        if (id == "" || pass == "") return false;
        else return true;
    }

    public void Registre()
    {
        if(!SetIDPass())
        {
            print("아이디 또는 비밀번호가 비었습니다.");
            return;
        }
        WWWForm form = new WWWForm();
        form.AddField("order", "register");
        form.AddField("id", id);
        form.AddField("pass", pass);

        StartCoroutine(Post(form));
    }

    public void Login()
    {
        if(!SetIDPass())
        {
            print("아이디 또는 비밀번호가 비어있습니다.");
            return;
        }
        WWWForm form = new WWWForm();
        form.AddField("order", "login");
        form.AddField("id", id);
        form.AddField("pass", pass);

        StartCoroutine(Post(form));
    }


    IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) print(www.downloadHandler.text);
            else print("웹의 응답이 없습니다.");
            www.Dispose();
        }
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