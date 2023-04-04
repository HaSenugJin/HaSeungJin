using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameObject game;
    private bool a;

    private void Awake()
    {
        game = Resources.Load("GameManager") as GameObject;
        a = true;
    }

    private void Update()
    {
        if(a)
        {
            GameObject Obj = Instantiate(game);
            Obj.transform.name = "GameManager";
            a = false;
        }
    }
}
