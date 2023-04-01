using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2B : MonoBehaviour
{
    private float Speed;

    // ** 총알이 충돌한 횟수
    private int hp;
    private GameObject Target;
    private float BulletDmg;
    // ** 총알이 날아가야할 방향
    public Vector3 Direction { get; set; }

    private void Awake()
    {
        Target = GameObject.Find("Player");
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
        BulletDmg = ControllerManager.GetInstance().WBulletDmg;
        // ** collision = 충돌한 대상. 
        if (collision.transform.tag == "Player")
        {
            ControllerManager.GetInstance().player_HP -= BulletDmg;
        }

        if (collision.transform.tag == "Wall")
            Destroy(this.gameObject, 0.016f);

        // ** 총알의 충돌 횟수가 0이 되면 총알 삭제.
        if (hp == 0)
        {
            Destroy(this.gameObject, 0.016f);
        }
    }
}
