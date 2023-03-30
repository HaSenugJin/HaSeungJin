using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Target;
    public float CoolDown;
    public float Speed;
    private GameObject BulletPrefab;
    private int HP;
    private Animator Anim;
    private Vector3 Movement;

    private float Direction;
    private bool Attack;

    private List<GameObject> Bullets = new List<GameObject>();


    private void Awake()
    {
        Target = GameObject.Find("Player");
        BulletPrefab = Resources.Load("Prefabs/Enemy/EnemyBullet") as GameObject;

        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        Speed = 2.0f;
        Movement = new Vector3(1.0f, 0.0f, 0.0f);
        HP = ControllerManager.GetInstance().EnemyHP;
        Attack = true;
    }

    void Update()
    {
        float Distance = Vector3.Distance(Target.transform.position, transform.position);
        Movement = ControllerManager.GetInstance().DirRight ?
        new Vector3(Speed + 1.0f, 0.0f, 0.0f) : new Vector3(Speed, 0.0f, 0.0f);

        if (Distance < 8.0f)
        {
            Attack = true;
            Anim.SetTrigger("Skill");
        }
        else if (Attack)
        {

            Anim.SetFloat("Speed", Movement.x);
            transform.position -= Movement * Time.deltaTime;
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            --HP;

            if(HP <= 0)
            {
                Anim.SetTrigger("Die");
                GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject, 0.016f);
    }

    private void attack()
    {
        Attack = false;
    }

    private void BU()
    {
        GameObject Obj = Instantiate(BulletPrefab);

        // ** ������ �Ѿ��� ��ġ�� ���� �÷��̾��� ��ġ�� �ʱ�ȭ�Ѵ�.
        Obj.transform.position = transform.position;

        // ** �Ѿ��� BullerController ��ũ��Ʈ�� �޾ƿ´�.
        BulletController Controller = Obj.AddComponent<BulletController>();

        // ** �Ѿ��� SpriteRenderer�� �޾ƿ´�.
        SpriteRenderer buleltRenderer = Obj.GetComponent<SpriteRenderer>();

        // ** ��� ������ ����Ǿ��ٸ� ����ҿ� �����Ѵ�.
        Bullets.Add(Obj);

    }
}
