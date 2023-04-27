using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private string game = "GameManager";
    private bool a;

    private void Awake()
    {
        a = true;
    }

    private void Update()
    {
        if(a)
        {
            GameObject Obj = Instantiate(pre.GetInstence.getPrefnbByName(game));

            Obj.transform.name = "GameManager";
            a = false;
        }
    }
}
