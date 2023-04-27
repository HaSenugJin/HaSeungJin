using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U9 : MonoBehaviour
{
    AudioSource audioSoure;
    public GameObject Target;
    private string BulletPrefab = "U9B";
    private string onSkill="B";

    public float CoolDown;
    public float Speed;

    public float HP;
    private Animator Anim;
    private Vector3 Movement;
    private bool Attack;
    private bool Skill;

    private List<GameObject> Bullets = new List<GameObject>();
    private List<GameObject> Skills = new List<GameObject>();



    private void Awake()
    {
        Target = GameObject.Find("Player");
        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        audioSoure = GetComponent<AudioSource>();
        Speed = 6.0f;
        Movement = new Vector3(1.0f, 0.0f, 0.0f);
        HP = ControllerManager.GetInstance().UHP;
        Attack = true;
        Skill = true;
    }

    void Update()
    {
        float Distance = Vector3.Distance(Target.transform.position, transform.position);
        Movement = ControllerManager.GetInstance().DirRight ?
        new Vector3(Speed + 1.0f, 0.0f, 0.0f) : new Vector3(Speed, 0.0f, 0.0f);

        if (Distance < 12.0f)
        {

            Anim.SetTrigger("Attack");
            Attack = true;
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

        if(HP <= 10.0f && Skill == true)
        {
            Anim.SetTrigger("Skill");

            GameObject Obj = Instantiate(pre.GetInstence.getPrefnbByName(onSkill));

            // ** ������ �Ѿ��� ��ġ�� ���� �÷��̾��� ��ġ�� �ʱ�ȭ�Ѵ�.
            Obj.transform.position = transform.position;

            // ** ��� ������ ����Ǿ��ٸ� ����ҿ� �����Ѵ�.
            Skills.Add(Obj);
            Skill = false;
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
        audioSoure.Play();
        GameObject Obj = Instantiate(pre.GetInstence.getPrefnbByName(BulletPrefab));

        // ** ������ �Ѿ��� ��ġ�� ���� �÷��̾��� ��ġ�� �ʱ�ȭ�Ѵ�.
        Obj.transform.position = transform.position;

        // ** ��� ������ ����Ǿ��ٸ� ����ҿ� �����Ѵ�.
        Bullets.Add(Obj);
    }
}
