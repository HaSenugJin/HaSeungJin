using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

public class LoginController : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycbwzwFulNGZgzlmNtrusrmJdqrOzs0eWIGhOGgYeYZKahT_GGACWDkZustH8vtwkDYYzKg/exec";
    public InputField emailinputField;
    private string emailpattern = @"^[\w-.]+@([\w-]+.)+[\w-]{2,4}$";

    public InputField passwardlnputField;
    public Text message;

    void Start()
    {
        message.text = "";
    }

    public void LoginCheck()
    {
        string email = emailinputField.text;

        if(Regex.IsMatch(email, emailpattern))
        {
            string password = Security(passwardlnputField.text);

            print(password);

            //로그인 작업 해주기


        }
        else
        {
            message.text = "이메일 형식을 다시 확인해 주십시오";
        }
    }

    string Security(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            message.text = "비밀번호를 입력하여 주십시오";
            return "null";
        }
        else
        {
            //패스워드의 암호및 복호화
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();

            foreach(byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
    }
}
