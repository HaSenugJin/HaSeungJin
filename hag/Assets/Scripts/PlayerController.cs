using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private float plyaerhp;
    // ** 움직임을 저장하는 벡터
    private Vector3 Movement;

    // ** 플레이어의 Animator 구성요소를 받아오기위해...
    private Animator animator;

    // ** 플레이어의 SpriteRenderer 구성요소를 받아오기위해...
    private SpriteRenderer playerRenderer;

    // ** 복제할 총알 원본
    private GameObject BulletPrefab;

    // ** 복제할 FX 원본
    private GameObject fxPrefab;

    // 추후 list로 변경
    public GameObject[] stageBack = new GameObject[7];

    /*
    Dictionary<string, object>;
    Dictionary<string, GameObject>;
     */

    // ** 복제된 총알의 저장공간.
    private List<GameObject> Bullets = new List<GameObject>();

    // ** 플레이어가 마지막으로 바라본 방향.
    private float Direction;

    [Header("방향")]
    // ** 플레이어가 바라보는 방향

    [Tooltip("왼쪽")]
    public bool DirLeft;
    [Tooltip("오른쪽")]
    public bool DirRight;
    public bool Attack;

    public float CoolDown;
    private bool playerdie;
    private bool Vectory;

    private void Awake()
    {
        // ** player 의 Animator를 받아온다.
        animator = this.GetComponent<Animator>();

        // ** player 의 SpriteRenderer를 받아온다.
        playerRenderer = this.GetComponent<SpriteRenderer>();

        // ** [Resources] 폴더에서 사용할 리소스를 들고온다.
        BulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        //fxPrefab = Resources.Load("Prefabs/FX/Smoke") as GameObject;
        fxPrefab = Resources.Load("Prefabs/FX/Hit") as GameObject;

        plyaerhp = ControllerManager.GetInstance().player_HP;
    }

    // ** 유니티 기본 제공 함수
    // ** 초기값을 설정할 때 사용
    void Start()
    {
        playerdie = false;
        Vectory = false;
        // ** 초기값 셋팅      

        Direction = 1.0f;
        Attack = false;
        DirLeft = false;

        for (int i = 0; i < 7; ++i)
            stageBack[i] = GameObject.Find(i.ToString());
    }

    // ** 유니티 기본 제공 함수
    // ** 프레임마다 반복적으로 실행되는 함수.
    void Update()
    {
        if (ControllerManager.GetInstance().EnemyKill >= 21)
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

        // **  Input.GetAxis =     -1 ~ 1 사이의 값을 반환함. 
        float Hor = Input.GetAxisRaw("Horizontal"); // -1 or 0 or 1 셋중에 하나를 반환.
        float Ver = Input.GetAxisRaw("Vertical"); // -1 or 0 or 1 셋중에 하나를 반환.

        // ** 입력받은 값으로 플레이어를 움직인다.
        Movement = new Vector3(
            Hor * Time.deltaTime * ControllerManager.GetInstance().PlayerSpeed,
            Ver * Time.deltaTime * (ControllerManager.GetInstance().PlayerSpeed * 0.5f),
            0.0f);

        transform.position += new Vector3(0.0f, Movement.y, 0.0f);

        // ** Hor이 0이라면 멈춰있는 상태이므로 예외처리를 해준다. 
        if (Hor != 0)
            Direction = Hor;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // ** 플레이어의 좌표가 17.0f 보다 작을때 플레이어를 움직인다.
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

            // ** 플레이어의 좌표가 -15.0 보다 클때 플레이어를 움직인다.
            if (transform.position.x > -15.0f && !Attack)
                // ** 실제 플레이어를 움직인다.
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
                // ** 공격모션을 실행 시킨다.
                animator.SetTrigger("Attack");
                Attack = true;
            }
            // ** 총알원본을 본제한다.
            GameObject Obj = Instantiate(BulletPrefab);

            // ** 복제된 총알의 위치를 현재 플레이어의 위치로 초기화한다.
            Obj.transform.position = transform.position;

            // ** 총알의 BullerController 스크립트를 받아온다.
            BulletController Controller = Obj.AddComponent<BulletController>();

            // ** 총알 스크립트내부의 방향 변수를 현재 플레이어의 방향 변수로 설정 한다.
            Controller.Direction = new Vector3(Direction, 0.0f, 0.0f);

            // ** 총알 스크립트내부의 FX Prefab을 설정한다.
            Controller.fxPrefab = fxPrefab;

            // ** 총알의 SpriteRenderer를 받아온다.
            SpriteRenderer buleltRenderer = Obj.GetComponent<SpriteRenderer>();

            // ** 총알의 이미지 반전 상태를 플레이어의 이미지 반전 상태로 설정한다.
            buleltRenderer.flipY = playerRenderer.flipX;

            // ** 모든 설정이 종료되었다면 저장소에 보관한다.
            Bullets.Add(Obj);
        }

        // ** 플레이어가 바라보고있는 방향에 따라 이미지 반전 설정.
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
            // ** 플레이의 움직임에 따라 이동 모션을 실행 한다.
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
