using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    void Update()
    {
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
