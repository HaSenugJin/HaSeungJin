using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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
        else if (Attack && HP > 0)
        {
            Anim.SetFloat("Speed", Movement.x);
            transform.position -= Movement * Time.deltaTime;
        }

        if (HP <= 0)
        {
            Anim.SetTrigger("Die");
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            HP -= ControllerManager.GetInstance().PlayerBulletDmg;
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject, 0.016f);
    }

    private void Moeny()
    {
        ControllerManager.GetInstance().moeny += 100;
    }

    private void attack()
    {
        Attack = true;
    }

    private void BU()
    {
        GameObject Obj = Instantiate(BulletPrefab);

        // ** 복제된 총알의 위치를 현재 플레이어의 위치로 초기화한다.
        Obj.transform.position = transform.position;

        // ** 모든 설정이 종료되었다면 저장소에 보관한다.
        Bullets.Add(Obj);
    }
}
