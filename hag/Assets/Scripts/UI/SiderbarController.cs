using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiderbarController : MonoBehaviour
{
    public GameObject sidebar;
    private Animator An;

    public bool check;


    private void Awake()
    {
        An = sidebar.GetComponent<Animator>();
    }

    void Start()
    {
        check = false;
    }



    public void ClickButton()
    {
        check = !check;

        An.SetBool("Move", check);
        
    }
}
