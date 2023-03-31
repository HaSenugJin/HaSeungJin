using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpbar : MonoBehaviour
{
    private Slider HPbar;

    private void Awake()
    {
        HPbar = GetComponent<Slider>();
    }

    private void Start()
    {
        HPbar.maxValue = ControllerManager.GetInstance().player_HP;
        HPbar.value = HPbar.maxValue;
    }

    private void Update()
    {
        HPbar.value = ControllerManager.GetInstance().player_HP;

        if(ControllerManager.GetInstance().player_HP <= 0)
        {

        }
    }
}
