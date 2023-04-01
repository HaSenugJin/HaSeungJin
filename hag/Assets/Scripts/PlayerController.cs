using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private float plyaerhp;
    // ** �������� �����ϴ� ����
    private Vector3 Movement;

    // ** �÷��̾��� Animator ������Ҹ� �޾ƿ�������...
    private Animator animator;

    // ** �÷��̾��� SpriteRenderer ������Ҹ� �޾ƿ�������...
    private SpriteRenderer playerRenderer;

    // ** ������ �Ѿ� ����
    private GameObject BulletPrefab;

    // ** ������ FX ����
    private GameObject fxPrefab;

    // ���� list�� ����
    public GameObject[] stageBack = new GameObject[7];

    /*
    Dictionary<string, object>;
    Dictionary<string, GameObject>;
     */

    // ** ������ �Ѿ��� �������.
    private List<GameObject> Bullets = new List<GameObject>();

    // ** �÷��̾ ���������� �ٶ� ����.
    private float Direction;

    [Header("����")]
    // ** �÷��̾ �ٶ󺸴� ����

    [Tooltip("����")]
    public bool DirLeft;
    [Tooltip("������")]
    public bool DirRight;
    public bool Attack;

    public float CoolDown;
    private bool playerdie;
    private bool Vectory;

    private void Awake()
    {
        // ** player �� Animator�� �޾ƿ´�.
        animator = this.GetComponent<Animator>();

        // ** player �� SpriteRenderer�� �޾ƿ´�.
        playerRenderer = this.GetComponent<SpriteRenderer>();

        // ** [Resources] �������� ����� ���ҽ��� ���´�.
        BulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        //fxPrefab = Resources.Load("Prefabs/FX/Smoke") as GameObject;
        fxPrefab = Resources.Load("Prefabs/FX/Hit") as GameObject;

        plyaerhp = ControllerManager.GetInstance().player_HP;
    }

    // ** ����Ƽ �⺻ ���� �Լ�
    // ** �ʱⰪ�� ������ �� ���
    void Start()
    {
        playerdie = false;
        Vectory = false;
        // ** �ʱⰪ ����      

        Direction = 1.0f;
        Attack = false;
        DirLeft = false;

        for (int i = 0; i < 7; ++i)
            stageBack[i] = GameObject.Find(i.ToString());
    }

    // ** ����Ƽ �⺻ ���� �Լ�
    // ** �����Ӹ��� �ݺ������� ����Ǵ� �Լ�.
    void Update()
    {
        if (ControllerManager.GetInstance().EnemyKill >= 3)
        {
            Vectory = true;

            GameObject ParentObj = GameObject.Find("EnemyList");

            List<GameObject> list = new List<GameObject>();

            for (int i = 0; i < ParentObj.transform.childCount; ++i)
            {
                EnemyController controller = ParentObj.transform.GetChild(i).GetComponent<EnemyController>();
                controller.HP = 0;
                //list.Add(ParentObj.transform.GetChild(i).gameObject);
            }

            animator.SetTrigger("Vectory");
        }
        if (Vectory) return;

        if (plyaerhp <= 0)
        {
            playerdie = true;
            animator.SetTrigger("Die");
        }
        if (playerdie) return;

        // **  Input.GetAxis =     -1 ~ 1 ������ ���� ��ȯ��. 
        float Hor = Input.GetAxisRaw("Horizontal"); // -1 or 0 or 1 ���߿� �ϳ��� ��ȯ.
        float Ver = Input.GetAxisRaw("Vertical"); // -1 or 0 or 1 ���߿� �ϳ��� ��ȯ.

        // ** �Է¹��� ������ �÷��̾ �����δ�.
        Movement = new Vector3(
            Hor * Time.deltaTime * ControllerManager.GetInstance().PlayerSpeed,
            Ver * Time.deltaTime * (ControllerManager.GetInstance().PlayerSpeed * 0.5f),
            0.0f);

        transform.position += new Vector3(0.0f, Movement.y, 0.0f);

        // ** Hor�� 0�̶�� �����ִ� �����̹Ƿ� ����ó���� ���ش�. 
        if (Hor != 0)
            Direction = Hor;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // ** �÷��̾��� ��ǥ�� 17.0f ���� ������ �÷��̾ �����δ�.
            if (transform.position.x < 17.0f && !Attack)
                transform.position += Movement;
            else
            {
                ControllerManager.GetInstance().DirRight = true;
                ControllerManager.GetInstance().DirLeft = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ControllerManager.GetInstance().DirRight = false;
            ControllerManager.GetInstance().DirLeft = true;

            // ** �÷��̾��� ��ǥ�� -15.0 ���� Ŭ�� �÷��̾ �����δ�.
            if (transform.position.x > -15.0f && !Attack)
                // ** ���� �÷��̾ �����δ�.
                transform.position += Movement;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || 
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            ControllerManager.GetInstance().DirRight = false;
            ControllerManager.GetInstance().DirLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            if (Attack == false)
            {
                // ** ���ݸ���� ���� ��Ų��.
                animator.SetTrigger("Attack");
                Attack = true;
            }
            // ** �Ѿ˿����� �����Ѵ�.
            GameObject Obj = Instantiate(BulletPrefab);

            // ** ������ �Ѿ��� ��ġ�� ���� �÷��̾��� ��ġ�� �ʱ�ȭ�Ѵ�.
            Obj.transform.position = transform.position;

            // ** �Ѿ��� BullerController ��ũ��Ʈ�� �޾ƿ´�.
            BulletController Controller = Obj.AddComponent<BulletController>();

            // ** �Ѿ� ��ũ��Ʈ������ ���� ������ ���� �÷��̾��� ���� ������ ���� �Ѵ�.
            Controller.Direction = new Vector3(Direction, 0.0f, 0.0f);

            // ** �Ѿ� ��ũ��Ʈ������ FX Prefab�� �����Ѵ�.
            Controller.fxPrefab = fxPrefab;

            // ** �Ѿ��� SpriteRenderer�� �޾ƿ´�.
            SpriteRenderer buleltRenderer = Obj.GetComponent<SpriteRenderer>();

            // ** �Ѿ��� �̹��� ���� ���¸� �÷��̾��� �̹��� ���� ���·� �����Ѵ�.
            buleltRenderer.flipY = playerRenderer.flipX;

            // ** ��� ������ ����Ǿ��ٸ� ����ҿ� �����Ѵ�.
            Bullets.Add(Obj);
        }

        // ** �÷��̾ �ٶ󺸰��ִ� ���⿡ ���� �̹��� ���� ����.
        if (Direction < 0)
        {
            playerRenderer.flipX = DirLeft = true;
        }
        else if (Direction > 0)
        {
            playerRenderer.flipX = false;
            DirRight = true;
        }

        if(!Attack)
        {
            // ** �÷����� �����ӿ� ���� �̵� ����� ���� �Ѵ�.
            animator.SetFloat("Speed", Hor);
        }
    }

    private void OnHit()
    {
        Attack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Back")
        {
            plyaerhp = 0.0f;
        }
    }
}
