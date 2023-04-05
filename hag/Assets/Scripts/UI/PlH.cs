using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlH : MonoBehaviour
{
    public Text mm;

    void Update()
    {
        mm.text = ControllerManager.GetInstance().player_HP.ToString();
    }
}
