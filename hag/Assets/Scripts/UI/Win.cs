using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject sidebar;
    private Animator An;

    private void Awake()
    {
        An = sidebar.GetComponent<Animator>();
    }

    private void Update()
    {
        if (ControllerManager.GetInstance().Win)
        {
            An.SetBool("Move", ControllerManager.GetInstance().Win);
        }
    }

    public void On()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("GameManager"));
    }
}
