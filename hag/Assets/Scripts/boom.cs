using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    void Update()
    {
        if(ControllerManager.GetInstance().boom)
        {
            GameObject ParentObj = GameObject.Find("EnemyList");

            List<GameObject> list = new List<GameObject>();

            for (int i = 0; i < ParentObj.transform.childCount; ++i)
            {
                EnemyController controller = ParentObj.transform.GetChild(i).GetComponent<EnemyController>();
                controller.HP = 0;
                //list.Add(ParentObj.transform.GetChild(i).gameObject);
            }

            /*
            foreach(GameObject element in list)
            {
                controller.HP = 0;
            }
             */

            ControllerManager.GetInstance().boom = false;
        }
    }
}
