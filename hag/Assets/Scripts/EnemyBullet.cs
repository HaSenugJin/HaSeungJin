using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float Speed;

    // ** �Ѿ��� �浹�� Ƚ��
    private int hp;

    // ** ����Ʈȿ�� ����
    //public GameObject fxPrefab;

    // ** �Ѿ��� ���ư����� ����
    public Vector3 Direction { get; set; }

    private void Start()
    {
        // ** �ӵ� �ʱⰪ
        Speed = ControllerManager.GetInstance().BulletSpeed;

        // ** �浹 Ƚ���� 3���� �����Ѵ�.
        hp = 1;
    }

    private void Update()
    {
        // ** �������� �ӵ���ŭ ��ġ�� ����
        transform.position += Direction * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ** �浹Ƚ�� ����.
        --hp;

        // ** ����Ʈȿ�� ����.
        //GameObject Obj = Instantiate(fxPrefab);

        // ** ����Ʈȿ���� ��ġ�� ����
        //Obj.transform.position = transform.position;

        // ** collision = �浹�� ���. 
        if (collision.transform.tag == "Player")
        {

        }

        // ** �Ѿ��� �浹 Ƚ���� 0�� �Ǹ� �Ѿ� ����.
        if (hp == 0)
            Destroy(this.gameObject, 0.016f);
    }
}
