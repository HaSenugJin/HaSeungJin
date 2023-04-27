using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour
{
    private float Speed;

    private GameObject Target;
    private float BulletDmg;
    private string fxPrefab = "Smoke";
    private string fxPrefab2 = "Hit";
    // ** �Ѿ��� ���ư����� ����
    public Vector3 Direction { get; set; }
    private int hp;
    private void Awake()
    {
        BulletDmg = ControllerManager.GetInstance().BDmg;
        Target = GameObject.Find("Player");
        
    }

    private void Start()
    {
        
        // ** �ӵ� �ʱⰪ
        Speed = 10.0f;
        hp = 7;
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
        // ** collision = �浹�� ���. 
        if (collision.transform.tag == "Player")
        {
            
            ControllerManager.GetInstance().player_HP -= BulletDmg;
            GameObject Obj = Instantiate(pre.GetInstence.getPrefnbByName(fxPrefab));

            // ** ����Ʈȿ���� ��ġ�� ����
            Obj.transform.position = transform.position;
            Destroy(this.gameObject, 0.016f);
        }

        if (collision.transform.tag == "Wall")
            Destroy(this.gameObject, 0.016f);

        if(collision.transform.tag == "Bullet")
        {
            --hp;
            GameObject Obj = Instantiate(pre.GetInstence.getPrefnbByName(fxPrefab2));

            // ** ����Ʈȿ���� ��ġ�� ����
            Obj.transform.position = transform.position;
            
            if(hp <= 0)
            {
                Destroy(this.gameObject, 0.016f);
            }
        }
    }
}
