using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager
{
    private ControllerManager() { }
    private static ControllerManager Instance = null;

    public static ControllerManager GetInstance()
    {
        if (Instance == null)
            Instance = new ControllerManager();
        return Instance;
    }

    public bool DirLeft;
    public bool DirRight;
    public bool boom = false;
    public bool loss = false;
    public bool Win = false;
    public bool Idle = true;
    public bool GameIsPaused = false;

    public float BulletSpeed = 10.0f;
    public float PlayerBulletDmg = 1.0f;
    public float player_HP = 20.0f;
    public float EnemyHP = 8.0f;
    public float EnemyBulletDmg = 1.0f;
    public float PlayerSpeed = 6.0f;
    public int moeny = 0;
    public int EnemyKill = 0;

    //W
    public float WHP = 80.0f;
    public float WBulletDmg = 7.0f;

    //u9
    public float UHP = 150.0f;
    public float UBulletDmg = 10.0f;
    public float BDmg = 25.0f;
}
