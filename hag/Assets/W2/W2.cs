using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2 : MonoBehaviour
{
    public GameObject Target;
    public float CoolDown;
    public float Speed;
    private GameObject BulletPrefab;
    public float HP;
    private Animator Anim;
    private Vector3 Movement;
    private bool Attack;

    private List<GameObject> Bullets = new List<GameObject>();


    private void Awake()
    {
        Target = GameObject.Find("Player");
        BulletPrefab = Resources.Load("Prefabs/Enemy/W2B") as GameObject;

        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        Speed = 6.0f;
        Movement = new Vector3(1.0f, 0.0f, 0.0f);
        HP = ControllerManager.GetInstance().WHP;
        Attack = true;
    }

    void Update()
    {
        float Distance = Vector3.Distance(Target.transform.position, transform.position);
        Movement = ControllerManager.GetInstance().DirRight ?
        new Vector3(Speed + 1.0f, 0.0f, 0.0f) : new Vector3(Speed, 0.0f, 0.0f);

        if (Distance < 12.0f)
        {
            Attack = true;
            Anim.SetTrigger("Attack");
        }
        else if (Attack && HP > 0 && ControllerManager.GetInstance().Idle)
        {
            Anim.SetFloat("Speed", Movement.x);
            transform.position -= Movement * Time.deltaTime;
        }

        if (HP <= 0)
        {

            Anim.SetTrigger("Die");
            GetComponent<CapsuleCollider2D>().enabled = false;
        }

        if (ControllerManager.GetInstance().player_HP <= 0.0f)
        {
            Anim.SetTrigger("Idle");
            ControllerManager.GetInstance().Idle = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            HP -= ControllerManager.GetInstance().PlayerBulletDmg;
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject, 0.030f);
    }

    private void Moeny()
    {
        ControllerManager.GetInstance().EnemyKill += 1;
        ControllerManager.GetInstance().moeny += 100;
    }

    private void attack()
    {
        Attack = true;
    }

    private void BU()
    {
        GameObject Obj = Instantiate(BulletPrefab);

        // ** ������ �Ѿ��� ��ġ�� ���� �÷��̾��� ��ġ�� �ʱ�ȭ�Ѵ�.
        Obj.transform.position = transform.position;

        // ** ��� ������ ����Ǿ��ٸ� ����ҿ� �����Ѵ�.
        Bullets.Add(Obj);
    }
}
