using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    private GameObject Parent = null;

    private string EnemyName = "Cube";

    private void Awake()
    {
        Parent = new GameObject("ObjectList");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(pre.GetInstence.getPrefnbByName(EnemyName)).transform.SetParent(Parent.transform);
        }
    }
}
