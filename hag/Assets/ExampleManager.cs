using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class MemberForm
{
    public string Name;
    public int Age;

    public MemberForm(string userName, int age)
    {
        this.Name = userName;
        this.Age = age;
    }
}

public class ExampleManager : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbyAGbUDytCx8bqaPh8MCILO1OIS30TBAw9RSkevz54oFZxVsIVDoJH7r9V4UxEhZ6w5SA/exec";

    IEnumerator Start()
    {
        //요청을 하기위한 작업
        //UnityWebRequest request = UnityWebRequest.Get(URL);

        MemberForm member = new MemberForm("변사또", 45);

        WWWForm from = new WWWForm();

        from.AddField("Name", member.Name);
        from.AddField("Age", member.Age);

        using (UnityWebRequest request = UnityWebRequest.Post(URL, from))
        {
            yield return request.SendWebRequest();

            //응답에 대한 작업
            print(request.downloadHandler.text);
        }
    }
}
