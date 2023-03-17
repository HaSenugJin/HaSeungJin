using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private float Speed;
    private Animator Anim;
    private GameObject Taget;
    private float CollDown;
    private int HP;
    private Vector3 Mov;
    private bool Skill;
    private bool Attack;
    private bool wa;
    private bool ac;
    private SpriteRenderer renderer;
    private int choice;


    private void Awake()
    {
        Taget = GameObject.Find("Player");

        Anim = GetComponent<Animator>();

        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        choice = 0;
        CollDown = 1.0f;
        Speed = 0.5f;
        HP = 30;
        Skill = false;
        Attack = false;
        ac = true;
        wa = true;
    }

    void Update()
    {
        float res = Taget.transform.position.x - transform.position.x;

        if (res < 0.0f)
        {
            renderer.flipX = true;
        }
        else if (res > 0.0f)
            renderer.flipX = false;

        Mov = ControllerManager.GetInstance().DirRight ?
        new Vector3(Speed + 1.0f, 0.0f, 0.0f) : new Vector3(Speed, 0.0f, 0.0f);

        transform.position -= Mov * Time.deltaTime;

        if (ac)
        {
            ac = false;
            StartCoroutine(onCollDown());
        }
    }

    private int onController()
    {
        Skill = false;
        Attack = false;
        wa = false;
            


        return Random.Range(0, 3);
    }

    private IEnumerator onCollDown()
    {
        float time = CollDown;

        while(time>0.0f)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        switch (Random.Range(0,3))
        {
            case 0:
                onAttack();
                break;

            case 1:
                onWalk();
                break;

            case 2:
                onSlide();
                break;
        }
        ac = true;
    }

    private void onAttack()
    {
        
    }

    private void onWalk()
    {
        
    }

    private void onSlide()
    {
        
    }
}
