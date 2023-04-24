using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

[System.Serializable]
public class MemberForm
{
    public string order, result, msg, value;
    public int money;
    public bool b;
}

public class ExampleManager : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycbwzwFulNGZgzlmNtrusrmJdqrOzs0eWIGhOGgYeYZKahT_GGACWDkZustH8vtwkDYYzKg/exec";
    public MemberForm me;
    public InputField IDInput, PassInput,ValueInput;
    string id, pass;
    private string emailpattern = @"^[\w-.]+@([\w-]+.)+[\w-]{2,4}$";
    public Text message;

    private void Start()
    {
        message.text = ""; 
        
    }

    bool SetIDPass()
    {
        id = IDInput.text.Trim();
        pass = PassInput.text.Trim();

        if (id == "" || pass == "") return false;
        else return true;
    }

    public void Registre()
    {
        string email = IDInput.text;

        if (!SetIDPass())
        {
            message.text = "아이디 또는 비밀번호가 비었습니다.";
            return;
        }

        if (Regex.IsMatch(email, emailpattern))
        {
            string password = Security(PassInput.text);
            WWWForm form = new WWWForm();
            form.AddField("order", "register");
            form.AddField("id", id);
            form.AddField("pass", pass);

            StartCoroutine(Post(form));
        }
        else
        {
            message.text = "이메일 형식이 잘못되었습니다.";
            return;
        }
    }

    public void Login()
    {
        if (!SetIDPass())
        {
            message.text = "아이디 또는 비밀번호가 비었습니다.";
            return;
        }
        string password = Security(PassInput.text);
        WWWForm form = new WWWForm();
        form.AddField("order", "login");
        form.AddField("id", id);
        form.AddField("pass", pass);
        
        StartCoroutine(login(form));
    }

    void OnApplicationQuit()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "logout");

        StartCoroutine(Post(form));
    }

    public void SetValue()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "setValue");
        form.AddField("value", ValueInput.text);

        StartCoroutine(Post(form));
    }

    public void GetValue()
    {
        WWWForm form = new WWWForm();
        
        form.AddField("order", "getValue");

        StartCoroutine(Post(form));
    }

    IEnumerator Post(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone)
            {
                Response(www.downloadHandler.text);
            }
            else message.text = "웹의 응답이 없습니다.";

        }
    }

    IEnumerator login(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone && me.b)
            {
                log(www.downloadHandler.text);
            }
            else if(me.b==false)
            {
                log(www.downloadHandler.text);
            }
            else message.text = "웹의 응답이 없습니다.";

        }
    }

    void Response(string json)
    {
        if (string.IsNullOrEmpty(json)) return;

        me = JsonUtility.FromJson<MemberForm>(json);
  
        if (me.result=="Error")
        {
            message.text = me.order + "을 실행할 수 없습니다. 에러 메시지 : " + me.msg;
            return;
        }

        message.text = me.order + "을 실행했습니다. 메시지 : " + me.msg;

        if(me.order=="getValue")
        {
            ValueInput.text = me.value;
        }
    }

    void log(string json)
    {
        if (string.IsNullOrEmpty(json)) return;
        
        me = JsonUtility.FromJson<MemberForm>(json);
        
        if (me.b == false)
        {
            print(me.msg);
            return;
        }

        message.text = me.order + "을 실행했습니다. 메시지 : " + me.msg;
        SceneManager.LoadScene("MainMenu");
    }

    string Security(string str)
    {
        //패스워드의 암호및 복호화
        SHA256 sha = new SHA256Managed();
        byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(str));
        StringBuilder stringBuilder = new StringBuilder();

        foreach (byte b in hash)
        {
            stringBuilder.AppendFormat("{0:x2}", b);
        }
        return stringBuilder.ToString();
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