using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    const int STATE_WALK = 1;
    const int STATE_ATTACK = 2;
    const int STATE_SLIDE = 3;

    private GameObject Target;
    private GameObject Boss;

    private Animator Anim;

    // ** �÷��̾��� SpriteRenderer ������Ҹ� �޾ƿ�������...
    private SpriteRenderer renderer;

    private Vector3 Movement;
    private Vector3 EndPoint;

    private float CoolDown;
    private float Speed;

    private bool SkillAttack;
    private bool Attack;
    private bool Walk;
    private bool active;

    private int choice;

    private void Awake()
    {
        Target = GameObject.Find("Player");
        Boss = GameObject.Find("Boss");

        Anim = GetComponent<Animator>();

        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        CoolDown = 1.5f;
        Speed = 1.0f;

        SkillAttack = false;
        Attack = false;

        active = true;

        SkillAttack = false;
        Attack = false;
        Walk = false;
    }

    void Update()
    {
        float result = Target.transform.position.x - transform.position.x;

        if (result < 0.0f)
            renderer.flipX = true;
        else if (result > 0.0f)
            renderer.flipX = false;

        if (ControllerManager.GetInstance().DirRight)
            transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime;


        if (active)
        {
            active = false;
            StartCoroutine(onCooldown());
            choice = onController();
        }
        else
        {
            switch (choice)
            {
                case STATE_WALK:
                    onWalk();
                    break;

                case STATE_ATTACK:
                    onAttack();
                    break;

                case STATE_SLIDE:
                    onSlide();
                    break;
            }
        }
    }

    private int onController()
    {
        // ** �ൿ ���Ͽ� ���� ������ �߰� �մϴ�.

        {
            // ** �ʱ�ȭ
            if (Walk)
            {
                Movement = new Vector3(0.0f, 0.0f, 0.0f);
                Anim.SetFloat("Speed", Movement.x);
                Walk = false;
            }

            if (SkillAttack)
            {
                SkillAttack = false;
            }
            

            if (Attack)
            {
                Attack = false;

            }

        }

        // ** ����

        // ** ���� �������� ���ϴ� ������ �÷��̾��� ��ġ�� ������������ ����.
        EndPoint = Target.transform.position;

        // * [return]
        // * 1 : �̵�         STATE_WALK
        // * 2 : ����         STATE_ATTACK
        // * 3 : �����̵�     STATE_SLIDE
        return Random.Range(STATE_WALK, STATE_SLIDE + 1);
    }


    private IEnumerator onCooldown()
    {
        float fTime = CoolDown;

        while (fTime > 0.0f)
        {
            fTime -= Time.deltaTime;
            yield return null;
        }

        fTime = 0.5f;
    }

    private void onAttack()
    {
  
        Attack = true;

        float Distance = Vector3.Distance(Target.transform.position, transform.position);


        if (Distance > 0.5f)
        {
            Attack = true;
            Anim.SetTrigger("Attack");
        }
        else
        {
            Attack = false;
        }

        if (!Attack)
        {
            Anim.SetFloat("Speed", Movement.x);
            transform.position -= Movement * Time.deltaTime;
        }

        active = true;
        
    }

    private void onWalk()
    {
        Walk = true;
        
        // ** �������� ������ ������......
        float Distance = Vector3.Distance(EndPoint, transform.position);

        if(Distance > 1.0f)
        {
            Vector3 Direction = (EndPoint - transform.position).normalized;

            Movement = new Vector3(
                Speed * Direction.x,
                Speed * Direction.y,
                0.0f);

            transform.position += Movement * Time.deltaTime;
            Anim.SetFloat("Speed", Mathf.Abs(Movement.x));
        }
        else
            active = true;
    }

    private void onSlide()
    {


        active = true;
    }
}
