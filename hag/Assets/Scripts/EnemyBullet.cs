using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float Speed;

    // ** �Ѿ��� �浹�� Ƚ��
    private int hp;

    private GameObject Target;

    // ** �Ѿ��� ���ư����� ����
    public Vector3 Direction { get; set; }

    private void Awake()
    {
        Target = GameObject.Find("Player");
    }

    private void Start()
    {
        // ** �ӵ� �ʱⰪ
        Speed = ControllerManager.GetInstance().BulletSpeed;

        // ** �浹 Ƚ���� �����Ѵ�.
        hp = 1;
    }

    private void Update()
    {
        // ** �������� �ӵ���ŭ ��ġ�� ����
        Target.transform.position -= transform.position * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ** �浹Ƚ�� ����.
        --hp;

        // ** collision = �浹�� ���. 
        if (collision.transform.tag == "Player")
        {

        }

        // ** �Ѿ��� �浹 Ƚ���� 0�� �Ǹ� �Ѿ� ����.
        if (hp == 0)
            Destroy(this.gameObject, 0.016f);
    }
}
