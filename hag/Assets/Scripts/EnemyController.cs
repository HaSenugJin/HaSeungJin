using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Target;
    public float CoolDown;
    public float Speed;

    private int HP;
    private Animator Anim;
    private Vector3 Movement;
    private GameObject Obj;
    private float Direction;
    private bool Attack;
    private GameObject fxPrefab;
    private List<GameObject> Bullets = new List<GameObject>();
    private GameObject BulletPrefab;

    private void Awake()
    {
        Target = GameObject.Find("Player");

        BulletPrefab = Resources.Load("Prefabs/Enemy/EnemyBullet") as GameObject;
        fxPrefab = Resources.Load("Prefabs/FX/Hit") as GameObject;
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
            StartCoroutine(OnAttack());
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
        //Attack = false;
    }

    IEnumerator OnAttack()
    {
        // ** �Ѿ˿����� �����Ѵ�.
        GameObject Obj = Instantiate(BulletPrefab);

        // ** ������ �Ѿ��� ��ġ�� ���� �÷��̾��� ��ġ�� �ʱ�ȭ�Ѵ�.
        Obj.transform.position = transform.position;

        // ** �Ѿ��� EnemyBullet ��ũ��Ʈ�� �޾ƿ´�.
        EnemyBullet Controller = Obj.AddComponent<EnemyBullet>();

        // ** �Ѿ� ��ũ��Ʈ������ ���� ������ ���� �÷��̾��� ���� ������ ���� �Ѵ�.
        Controller.Direction = new Vector3(Direction, 0.0f, 0.0f);

        // ** �Ѿ� ��ũ��Ʈ������ FX Prefab�� �����Ѵ�.
        //Controller.fxPrefab = BulletPrefab;

        // ** �Ѿ��� SpriteRenderer�� �޾ƿ´�.
        //SpriteRenderer buleltRenderer = Obj.GetComponent<SpriteRenderer>();

        // ** ��� ������ ����Ǿ��ٸ� ����ҿ� �����Ѵ�.
        Bullets.Add(Obj);

        while (CoolDown > 0.0f)
        {
            CoolDown -= Time.deltaTime;
            yield return null;
        }
        Attack = false;
        CoolDown = 5.0f;
        
    }
}
