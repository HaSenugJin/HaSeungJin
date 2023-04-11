using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyManager() { }
    private static EnemyManager instance = null;

    private bool W2;
    private bool U9;
    private GameObject Wspown;
    private GameObject Uspown;


    private int Enemy;

    public static EnemyManager GetInstance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    // ** 생성되는 Enemy를 담아둘 상위 객체
    private GameObject Parent;

    // ** Enemy로 사용할 원형 객체
    private GameObject Prefab;

    // ** 플레이어의 누적 이동 거리
    public float Distance;

    private void Awake()
    {
        W2 = true;
        U9 = true;
        
        if (instance == null)
        {
            instance = this;

            Distance = 0.0f;

            // ** 씬이 변경되어도 계속 유지될 수 있게 해준다.
            DontDestroyOnLoad(gameObject);

            // ** 생성되는 Enemy를 담아둘 상위 객체
            Parent = new GameObject("EnemyList");

            // ** Enemy로 사용할 원형 객체
            Prefab = Resources.Load("Prefabs/Enemy/Enemy") as GameObject;

            Wspown = Resources.Load("W2") as GameObject;
            Uspown = Resources.Load("U9") as GameObject;
        }
    }

    // ** 시작하자마자 Start함수를 코루틴 함수로 실행
    private IEnumerator Start()
    {
        while(Enemy <= 48 && ControllerManager.GetInstance().Idle && ControllerManager.GetInstance().Win == false)
        {
            ++Enemy;
            // ** Enemy 원형객체를 복제한다.
            GameObject Obj = Instantiate(Prefab);

            // ** Enemy 작동 스크립트 포함.
            //Obj.AddComponent<EnemyController>();

            // ** 클론의 위치를 초기화.
            Obj.transform.position = new Vector3(
                18.0f, Random.Range(-8.2f, -5.2f), 0.0f);

            // ** 클론의 이름 초기화.
            Obj.transform.name = "Enemy";

            // ** 클론의 계층구조 설정.
            Obj.transform.parent = Parent.transform;

            // ** 1.5초 휴식.
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void Update()
    {
        if (ControllerManager.GetInstance().DirRight)
        {
            Distance += Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        }

        if(W2 == true)
        {
            if (ControllerManager.GetInstance().EnemyKill >= 30)
            {
                // ** Enemy 원형객체를 복제한다.
                GameObject Obj = Instantiate(Wspown);

                // ** 클론의 위치를 초기화.
                Obj.transform.position = new Vector3(
                    18.0f, Random.Range(-8.2f, -5.2f), 0.0f);

                W2 = false;
            }
        }

        if (U9 == true)
        {
            if (ControllerManager.GetInstance().EnemyKill >= 50)
            {
                // ** Enemy 원형객체를 복제한다.
                GameObject Obj = Instantiate(Uspown);

                // ** 클론의 위치를 초기화.
                Obj.transform.position = new Vector3(
                    18.0f, Random.Range(-8.2f, -5.2f), 0.0f);

                U9 = false;
            }
        }
    }
}
