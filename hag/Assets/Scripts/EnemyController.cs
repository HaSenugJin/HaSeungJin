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
        // ** 총알원본을 본제한다.
        GameObject Obj = Instantiate(BulletPrefab);

        // ** 복제된 총알의 위치를 현재 플레이어의 위치로 초기화한다.
        Obj.transform.position = transform.position;

        // ** 총알의 EnemyBullet 스크립트를 받아온다.
        EnemyBullet Controller = Obj.AddComponent<EnemyBullet>();

        // ** 총알 스크립트내부의 방향 변수를 현재 플레이어의 방향 변수로 설정 한다.
        Controller.Direction = new Vector3(Direction, 0.0f, 0.0f);

        // ** 총알 스크립트내부의 FX Prefab을 설정한다.
        //Controller.fxPrefab = BulletPrefab;

        // ** 총알의 SpriteRenderer를 받아온다.
        //SpriteRenderer buleltRenderer = Obj.GetComponent<SpriteRenderer>();

        // ** 모든 설정이 종료되었다면 저장소에 보관한다.
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
