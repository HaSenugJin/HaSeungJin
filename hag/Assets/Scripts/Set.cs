using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(ControllerManager.GetInstance().GameIsPaused == false)
            On();
            else
            off();
        }


        if (ControllerManager.GetInstance().GameIsPaused == false)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void On()
    {
        ControllerManager.GetInstance().GameIsPaused = true;
    }

    public void off()
    {
        ControllerManager.GetInstance().GameIsPaused = false;
    }
}
