using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SiderbarController : MonoBehaviour
{
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
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("GameManager"));
    }
}
