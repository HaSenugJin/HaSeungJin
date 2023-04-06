using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void GameStart()
    {
        ControllerManager.GetInstance().GameIsPaused = false;
        ControllerManager.GetInstance().boom = false;
        ControllerManager.GetInstance().loss = false;
        ControllerManager.GetInstance().Win = false;
        ControllerManager.GetInstance().Idle = true;
        ControllerManager.GetInstance().BulletSpeed = 10.0f;
        ControllerManager.GetInstance().PlayerBulletDmg = 1.0f;
        ControllerManager.GetInstance().player_HP = 20.0f;
        ControllerManager.GetInstance().PlayerSpeed = 6.0f;
        ControllerManager.GetInstance().moeny = 0;
        ControllerManager.GetInstance().EnemyKill = 0;
        ControllerManager.GetInstance().WHP = 40.0f;
        ControllerManager.GetInstance().UHP = 60.0f;
        ControllerManager.GetInstance().EnemyHP = 8.0f;
        SceneManager.LoadScene("Game Start");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
