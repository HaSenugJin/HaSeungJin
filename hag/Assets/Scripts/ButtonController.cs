using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void GameStart()
    {
        ControllerManager.GetInstance().GameIsPaused = true;
        ControllerManager.GetInstance().boom = false;
        ControllerManager.GetInstance().loss = false;
        ControllerManager.GetInstance().Win = false;
        ControllerManager.GetInstance().Idle = true;
        ControllerManager.GetInstance().BulletSpeed = 10.0f;
        ControllerManager.GetInstance().PlayerBulletDmg = 1.0f;
        ControllerManager.GetInstance().player_HP = 20.0f;
        ControllerManager.GetInstance().EnemyHP = 7.0f;
        ControllerManager.GetInstance().EnemyBulletDmg = 1.0f;
        ControllerManager.GetInstance().PlayerSpeed = 5.0f;
        ControllerManager.GetInstance().moeny = 0;
        ControllerManager.GetInstance().EnemyKill = 0;
        ControllerManager.GetInstance().WHP = 20.0f;
        ControllerManager.GetInstance().WBulletDmg = 2.0f;
        ControllerManager.GetInstance().UHP = 30.0f;
        ControllerManager.GetInstance().UBulletDmg = 4.0f;
        ControllerManager.GetInstance().BDmg = 6.0f;
        SceneManager.LoadScene("Game Start");
    }
}
