using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Kill : MonoBehaviour
{
    public Text mm;

    void Update()
    {
        mm.text = ControllerManager.GetInstance().EnemyKill.ToString();
    }
}
