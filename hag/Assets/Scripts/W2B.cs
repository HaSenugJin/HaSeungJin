using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2B : MonoBehaviour
{
    private float Speed;

    // ** �Ѿ��� �浹�� Ƚ��
    private int hp;
    private GameObject Target;
    private float BulletDmg;
    // ** �Ѿ��� ���ư����� ����
    public Vector3 Direction { get; set; }

    private void Awake()
    {
        Target = GameObject.Find("Player");
    }

    private void Start()
    {
        // ** �ӵ� �ʱⰪ
        Speed = 15.0f;

        // ** �浹 Ƚ���� �����Ѵ�.
        hp = 1;
        Direction = (Target.transform.position - transform.position);
        Direction.Normalize();
    }

    private void Update()
    {
        Direction = (Target.transform.position - transform.position).normalized;
        // ** �������� �ӵ���ŭ ��ġ�� ����
        transform.position += Direction * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ** �浹Ƚ�� ����.
        --hp;
        BulletDmg = ControllerManager.GetInstance().WBulletDmg;
        // ** collision = �浹�� ���. 
        if (collision.transform.tag == "Player")
        {
            ControllerManager.GetInstance().player_HP -= BulletDmg;
        }

        if (collision.transform.tag == "Wall")
            Destroy(this.gameObject, 0.016f);

        // ** �Ѿ��� �浹 Ƚ���� 0�� �Ǹ� �Ѿ� ����.
        if (hp == 0)
        {
            Destroy(this.gameObject, 0.016f);
        }
    }
}
