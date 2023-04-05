using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private List<GameObject> Images = new List<GameObject>();
    private List<GameObject> Buttons = new List<GameObject>();
    private List<Image> ButtonImages = new List<Image>();

    private void Start()
    {
        GameObject SkillsObj = GameObject.Find("Skills");

        for (int i = 0; i < SkillsObj.transform.childCount; ++i)
        {
            GameObject obj = SkillsObj.transform.GetChild(i).gameObject;
            Images.Add(obj);
            Buttons.Add(obj.transform.GetChild(0).gameObject);
            ButtonImages.Add(obj.transform.GetChild(0).GetComponent<Image>());
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            skill1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            skill2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            skill3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            skill4();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            skill5();
        }
    }

    public void skill1()
    {
        ButtonImages[0].fillAmount = 0;
        Buttons[0].GetComponent<Button>().enabled = false;
        //StartCoroutine(pushbutton_c(0, 0.5f));

        if (ControllerManager.GetInstance().moeny >= 500)
        {
            ControllerManager.GetInstance().BulletSpeed += 5.0f;
            ControllerManager.GetInstance().moeny -= 500;
        }
    }

    public void skill2()
    {
        ButtonImages[1].fillAmount = 0;
        Buttons[1].GetComponent<Button>().enabled = false;
        //StartCoroutine(pushbutton_c(1, 0.5f));

        if (ControllerManager.GetInstance().moeny >= 500)
        {
            ControllerManager.GetInstance().PlayerBulletDmg += 0.5f;
            ControllerManager.GetInstance().moeny -= 500;
        }
    }

    public void skill3()
    {
        ButtonImages[2].fillAmount = 0;
        Buttons[2].GetComponent<Button>().enabled = false;
        //StartCoroutine(pushbutton_c(2, 0.5f));
        if (ControllerManager.GetInstance().moeny >= 500)
        {
            ControllerManager.GetInstance().player_HP += 1.0f;
            ControllerManager.GetInstance().moeny -= 500;
        }
    }

    public void skill4()
    {
        ButtonImages[3].fillAmount = 0;
        Buttons[3].GetComponent<Button>().enabled = false;
        //StartCoroutine(pushbutton_c(3, 0.5f));
        if (ControllerManager.GetInstance().moeny >= 500)
        {
            ControllerManager.GetInstance().PlayerSpeed += 1.0f;
            ControllerManager.GetInstance().moeny -= 500;
        }
    }

    public void skill5()
    {
        ButtonImages[4].fillAmount = 0;
        Buttons[4].GetComponent<Button>().enabled = false;
        //StartCoroutine(pushbutton_c(4, 0.5f));

        if (ControllerManager.GetInstance().moeny >= 1000)
        {
            ControllerManager.GetInstance().moeny -= 1000;
            if (ControllerManager.GetInstance().boom == false)
            {
                ControllerManager.GetInstance().boom = true;
            }
        }
    }

    /*
    IEnumerator pushbutton_c(int _inedx, float cooldown)
    {
        while(ButtonImages[_inedx].fillAmount!=1)
        {
            ButtonImages[_inedx].fillAmount += Time.deltaTime * cooldown;
            yield return null;
        }
        Buttons[_inedx].GetComponent<Button>().enabled = true;
    }
    */
}