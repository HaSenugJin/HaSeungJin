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
        if(Input.GetMouseButton(0))
        {
            ControllerManager.GetInstance().player_HP -= 1;
        }

        if (Input.GetMouseButton(1))
        {
            ControllerManager.GetInstance().player_HP += 1;
        }

        HPbar.value = ControllerManager.GetInstance().player_HP;

        if(ControllerManager.GetInstance().player_HP <= 0)
        {

        }
    }
}
