using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float Speed;

    // ** �Ѿ��� �浹�� Ƚ��
    private int hp;
    private GameObject Target;
    private float BulletDmg;
    private GameObject fxPrefab;
    // ** �Ѿ��� ���ư����� ����
    public Vector3 Direction { get; set; }

    private void Awake()
    {
        Target = GameObject.Find("Player");
        fxPrefab = Resources.Load("Prefabs/FX/Hit") as GameObject;
        BulletDmg = ControllerManager.GetInstance().EnemyBulletDmg;
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

        GameObject Obj = Instantiate(fxPrefab);

        // ** ����Ʈȿ���� ��ġ�� ����
        Obj.transform.position = transform.position;

        // ** collision = �浹�� ���. 
        if (collision.transform.tag == "Player")
        {
            ControllerManager.GetInstance().player_HP -= BulletDmg;
            Destroy(this.gameObject, 0.016f);
        }

        if(collision.transform.tag == "Wall")
            Destroy(this.gameObject, 0.016f);

        // ** �Ѿ��� �浹 Ƚ���� 0�� �Ǹ� �Ѿ� ����.
        if (hp == 0)
        {
            Destroy(this.gameObject, 0.016f);
        }
    }
}
