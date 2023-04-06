using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setS : MonoBehaviour
{
    public GameObject set;
    private Vector3 Movement;
    private Vector3 Movement2;

    private void Awake()
    {
        set = GameObject.Find("MenuCanvas/set");
    }

    private void Update()
    {
        if(ControllerManager.GetInstance().loss==false && ControllerManager.GetInstance().Win == false)
        {
            if (ControllerManager.GetInstance().GameIsPaused)
            {
                set.transform.position = new Vector3(-987.0f, 540.0f, 0.0f);
            }
            else
            {
                set.transform.position = new Vector3(960.0f, 540.0f, 0.0f);
            }
        }
    }
}
