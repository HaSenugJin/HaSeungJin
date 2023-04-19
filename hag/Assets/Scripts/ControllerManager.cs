using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Info
{
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
*/

public class ControllerManager
{
    private ControllerManager() { }

    /*
    public ControllerManager(bool boom, bool loss, bool win, bool idle, bool gameIsPaused, float bulletSpeed, float playerBulletDmg, float player_HP, float enemyHP, float enemyBulletDmg, float playerSpeed, int moeny, int enemyKill, float wHP, float wBulletDmg, float uHP, float uBulletDmg, float bDmg)
    {
        
        this.info.boom = boom;
        this.info.loss = loss;
        this.info.Win = win;
        this.info.Idle = idle;
        this.info.GameIsPaused = gameIsPaused;
        this.info.BulletSpeed = bulletSpeed;
        this.info.PlayerBulletDmg = playerBulletDmg;
        this.info.player_HP = player_HP;
        this.info.EnemyHP = enemyHP;
        this.info.EnemyBulletDmg = enemyBulletDmg;
        this.info.PlayerSpeed = playerSpeed;
        this.info.moeny = moeny;
        this.info.EnemyKill = enemyKill;
        this.info.WHP = wHP;
        this.info.WBulletDmg = wBulletDmg;
        this.info.UHP = uHP;
        this.info.UBulletDmg = uBulletDmg;
        this.info.BDmg = bDmg;
        
    }
    */
    private static ControllerManager Instance = null;

    public static ControllerManager GetInstance()
    {
        if (Instance == null)
        {
            //Instance = new ControllerManager(false, false, false, true, false, 10.0f, 1.0f, 20.0f, 8.0f, 1.0f, 6.0f, 0, 0, 80.0f, 7.0f, 150.0f, 10.0f, 25.0f);
            Instance = new ControllerManager();
        }
        return Instance;
    }
    
    //public Info info;
    
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
    public int bullethp = 1;

    //W
    public float WHP = 80.0f;
    public float WBulletDmg = 7.0f;

    //u9
    public float UHP = 150.0f;
    public float UBulletDmg = 10.0f;
    public float BDmg = 25.0f;
}
