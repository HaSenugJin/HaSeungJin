using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{
    // ** ����ٴ� ��ü
    public GameObject Target;
    public GameObject HPbar;

    // ** ������ġ ����
    private Vector3 offset;

    /*
    private void Start()
    {
        // ** ��ġ ����
        offset = new Vector3(0.0f, 0.6f, 0.0f);
        //Target = GameObject.Find("Boss") as GameObject;

        HPbar = Resources.Load("Prefabs/HP") as GameObject;
    }

    private void Update()
    {
        // ** WorldToScreenPoint = ������ǥ�� ī�޶� ��ǥ�� ��ȯ.
        // ** ����� �ִ� Ÿ���� ��ǥ�� ī�޶� ��ǥ�� ��ȯ�Ͽ�, UI�� �����Ѵ�.
        //transform.position = Camera.main.WorldToScreenPoint(Target.transform.position + offset);
        Destroy(gameObject);
    }
    */
}
