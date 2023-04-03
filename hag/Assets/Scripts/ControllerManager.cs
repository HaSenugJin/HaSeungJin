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
    public bool boom=false;
    public bool Stun = false;

    public float BulletSpeed = 10.0f;
    public float PlayerBulletDmg = 1.0f;
    public float player_HP = 20.0f;
    public float EnemyHP = 7.0f;
    public float EnemyBulletDmg = 1.0f;
    public float PlayerSpeed = 5.0f;
    public int moeny = 10000;
    public int EnemyKill=0;

    //W
    public float WHP = 20.0f;
    public float WBulletDmg = 2.0f;

    //u9
    public float UHP = 30.0f;
    public float UBulletDmg = 4.0f;
    public float BDmg = 6.0f;
}
