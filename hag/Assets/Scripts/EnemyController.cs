using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Target;

    public float Speed;
    public int HP;
    private Animator Anim;
    private Vector3 Movement;

    private float CoolDown;
    private bool Attack;
    private bool Run;
    private bool SkillAttack;

    private List<GameObject> Bullets = new List<GameObject>();
    private GameObject BulletPrefab;

    private void Awake()
    {
        Target = GameObject.Find("Player");
        BulletPrefab = Resources.Load("Prefabs/Enemy/EnemyBullet") as GameObject;
        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        Speed = 0.2f;
        Movement = new Vector3(1.0f, 0.0f, 0.0f);
        HP = 3;

        Attack = false;
        SkillAttack = true;
        CoolDown = 5.0f;
    }

    void Update()
    {
        Movement = ControllerManager.GetInstance().DirRight ? 
            new Vector3(Speed + 1.0f, 0.0f, 0.0f) : new Vector3(Speed, 0.0f, 0.0f);

        float Distance = Vector3.Distance(Target.transform.position, transform.position);

        if (Distance < 0.5f)
        {
            Attack = true;
            Anim.SetTrigger("Attack");
        }
        else if (Distance < 8.0f && !Attack)
        {
            if (SkillAttack)
            {
                Attack = true;
                SkillAttack = false;
                StartCoroutine(Skill());
            }
        }
        else
        {
            Attack = false;
        }

        if(!Attack)
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

            if(HP <= 0 )
            {
                Anim.SetTrigger("Die");
                GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }

    IEnumerator Skill()
    {
        Anim.SetTrigger("Skill");

        GameObject Obj = Instantiate(BulletPrefab);

        Obj.transform.position = Target.transform.position;

        // ** 총알의 BullerController 스크립트를 받아온다.
        EnemyBullet Controller = Obj.AddComponent<EnemyBullet>();

        // ** 총알의 SpriteRenderer를 받아온다.
        SpriteRenderer buleltRenderer = Obj.GetComponent<SpriteRenderer>();

        // ** 모든 설정이 종료되었다면 저장소에 보관한다.
        Bullets.Add(Obj);

        while (CoolDown > 0.0f)
        {
            CoolDown -= Time.deltaTime;
            yield return null;
        }

        CoolDown = 1.0f;
    }


    private void DestroyEnemy()
    {
        Destroy(gameObject, 0.016f);
    }
}
