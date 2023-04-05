using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour
{
    private float Speed;

    private GameObject Target;
    private float BulletDmg;
    public GameObject fxPrefab;
    public GameObject fxPrefab2;
    // ** 총알이 날아가야할 방향
    public Vector3 Direction { get; set; }
    private int hp;
    private void Awake()
    {
        BulletDmg = ControllerManager.GetInstance().BDmg;
        Target = GameObject.Find("Player");
        fxPrefab = Resources.Load("Prefabs/FX/Smoke") as GameObject;
        fxPrefab2 = Resources.Load("Prefabs/FX/Hit") as GameObject;
    }

    private void Start()
    {
        
        // ** 속도 초기값
        Speed = 10.0f;
        hp = 7;
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
        // ** collision = 충돌한 대상. 
        if (collision.transform.tag == "Player")
        {
            
            ControllerManager.GetInstance().player_HP -= BulletDmg;
            GameObject Obj = Instantiate(fxPrefab);

            // ** 이펙트효과의 위치를 지정
            Obj.transform.position = transform.position;
            Destroy(this.gameObject, 0.016f);
        }

        if (collision.transform.tag == "Wall")
            Destroy(this.gameObject, 0.016f);

        if(collision.transform.tag == "Bullet")
        {
            --hp;
            GameObject Obj = Instantiate(fxPrefab2);

            // ** 이펙트효과의 위치를 지정
            Obj.transform.position = transform.position;
            
            if(hp <= 0)
            {
                Destroy(this.gameObject, 0.016f);
            }
        }
    }
}
