using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float Speed;

    // ** 총알이 충돌한 횟수
    private int hp;

    // ** 이펙트효과 원본
    //public GameObject fxPrefab;

    // ** 총알이 날아가야할 방향
    public Vector3 Direction { get; set; }

    private void Start()
    {
        // ** 속도 초기값
        Speed = ControllerManager.GetInstance().BulletSpeed;

        // ** 충돌 횟수를 3으로 지정한다.
        hp = 1;
    }

    private void Update()
    {
        // ** 방향으로 속도만큼 위치를 변경
        transform.position += Direction * Speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ** 충돌횟수 차감.
        --hp;

        // ** 이펙트효과 복제.
        //GameObject Obj = Instantiate(fxPrefab);

        // ** 이펙트효과의 위치를 지정
        //Obj.transform.position = transform.position;

        // ** collision = 충돌한 대상. 
        if (collision.transform.tag == "Player")
        {

        }

        // ** 총알의 충돌 횟수가 0이 되면 총알 삭제.
        if (hp == 0)
            Destroy(this.gameObject, 0.016f);
    }
}
