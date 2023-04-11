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

    // ** �����Ǵ� Enemy�� ��Ƶ� ���� ��ü
    private GameObject Parent;

    // ** Enemy�� ����� ���� ��ü
    private GameObject Prefab;

    // ** �÷��̾��� ���� �̵� �Ÿ�
    public float Distance;

    private void Awake()
    {
        W2 = true;
        U9 = true;
        
        if (instance == null)
        {
            instance = this;

            Distance = 0.0f;

            // ** ���� ����Ǿ ��� ������ �� �ְ� ���ش�.
            DontDestroyOnLoad(gameObject);

            // ** �����Ǵ� Enemy�� ��Ƶ� ���� ��ü
            Parent = new GameObject("EnemyList");

            // ** Enemy�� ����� ���� ��ü
            Prefab = Resources.Load("Prefabs/Enemy/Enemy") as GameObject;

            Wspown = Resources.Load("W2") as GameObject;
            Uspown = Resources.Load("U9") as GameObject;
        }
    }

    // ** �������ڸ��� Start�Լ��� �ڷ�ƾ �Լ��� ����
    private IEnumerator Start()
    {
        while(Enemy <= 48 && ControllerManager.GetInstance().Idle && ControllerManager.GetInstance().Win == false)
        {
            ++Enemy;
            // ** Enemy ������ü�� �����Ѵ�.
            GameObject Obj = Instantiate(Prefab);

            // ** Enemy �۵� ��ũ��Ʈ ����.
            //Obj.AddComponent<EnemyController>();

            // ** Ŭ���� ��ġ�� �ʱ�ȭ.
            Obj.transform.position = new Vector3(
                18.0f, Random.Range(-8.2f, -5.2f), 0.0f);

            // ** Ŭ���� �̸� �ʱ�ȭ.
            Obj.transform.name = "Enemy";

            // ** Ŭ���� �������� ����.
            Obj.transform.parent = Parent.transform;

            // ** 1.5�� �޽�.
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
                // ** Enemy ������ü�� �����Ѵ�.
                GameObject Obj = Instantiate(Wspown);

                // ** Ŭ���� ��ġ�� �ʱ�ȭ.
                Obj.transform.position = new Vector3(
                    18.0f, Random.Range(-8.2f, -5.2f), 0.0f);

                W2 = false;
            }
        }

        if (U9 == true)
        {
            if (ControllerManager.GetInstance().EnemyKill >= 50)
            {
                // ** Enemy ������ü�� �����Ѵ�.
                GameObject Obj = Instantiate(Uspown);

                // ** Ŭ���� ��ġ�� �ʱ�ȭ.
                Obj.transform.position = new Vector3(
                    18.0f, Random.Range(-8.2f, -5.2f), 0.0f);

                U9 = false;
            }
        }
    }
}
