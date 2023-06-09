using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float Speed;

    // ** 총알이 충돌한 횟수
    private int hp;
    private GameObject Target;
    private float BulletDmg;
    private GameObject Parent = null;
    private string fxPre = "Hit";
    // ** 총알이 날아가야할 방향
    public Vector3 Direction { get; set; }

    private void Awake()
    {
        Target = GameObject.Find("Player");
        Parent = new GameObject("hit");
        //fxPrefab = Resources.Load("Prefabs/FX/Hit") as GameObject;
        BulletDmg = ControllerManager.GetInstance().EnemyBulletDmg;
    }

    private void Start()
    {
        // ** 속도 초기값
        Speed = 15.0f;

        // ** 충돌 횟수를 지정한다.
        hp = 1;
        Direction = (Target.transform.position - transform.position);
        Direction.Normalize();
    }

    private void Update()
    {
        Direction = (Target.transform.position - transform.position).normalized;
        // ** 방향으로 속도만큼 위치를 변경
        transform.position += Direction * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ** 충돌횟수 차감.
        --hp;

        GameObject Obj = Instantiate(pre.GetInstence.getPrefnbByName(fxPre));

        // ** 이펙트효과의 위치를 지정
        Obj.transform.position = transform.position;

        // ** 클론의 이름 초기화.
        Obj.transform.name = "hit";

        // ** 클론의 계층구조 설정.
        Obj.transform.parent = Parent.transform;

        // ** collision = 충돌한 대상. 
        if (collision.transform.tag == "Player")
        {
            ControllerManager.GetInstance().player_HP -= BulletDmg;
            Destroy(this.gameObject, 0.016f);
        }

        if(collision.transform.tag == "Wall")
            Destroy(this.gameObject, 0.016f);

        // ** 총알의 충돌 횟수가 0이 되면 총알 삭제.
        if (hp == 0)
        {
            Destroy(this.gameObject, 0.016f);
        }
    }
}
