using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MemberForm
{
    public int gender;
    public string name;
    public int index;
    public int age;

    public MemberForm(int gender, string name, int index, int age)
    {
        this.gender = gender;
        this.name = name;
        this.index = index;
        this.age = age;
    }
}

public class ExampleManager : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbyFdsBmsUbLCBHusOyYEzuH5zy6KL79PNsDpCXWxRW-Ve9V0mtrKj69nKdI2DW1-4bdNQ/exec";

    IEnumerator Start()
    {
        //요청을 하기위한 작업
        //UnityWebRequest request = UnityWebRequest.Get(URL);

        /*
        MemberForm member = new MemberForm("변사또", 45);

        WWWForm from = new WWWForm();

        from.AddField("Name", member.Name);
        from.AddField("Age", member.Age);
        */

        

        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            MemberForm json = JsonUtility.FromJson<MemberForm>(request.downloadHandler.text);

            //응답에 대한 작업
            print(json.index);
            print(json.name);
            print(json.age);
            print(json.gender);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("ProgressScene");
    }
}
