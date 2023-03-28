using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{

    public GameObject[] backgrounds = new GameObject[4];

    // ** BackGround �� ���ִ� ���������� �ֻ��� ��ü(�θ�)
    private Transform parent;

    // ** Sprite�� �����ϰ� �ִ� �������
    private SpriteRenderer[] spriteRenderers = new SpriteRenderer[4];

    // ** �̹���
    private Sprite[] sprites = new Sprite[4];

    // ** ��������
    private float endPoint;

    // ** ���� ����.
    private float exitPoint;

    // ** �̹��� �̵��ӵ�
    public float Speed;

    // ** �÷��̾� ����
    private GameObject player;
    private PlayerController playerController;

    // ** ������ ����
    private Vector3 movemane;

    // ** �̹����� �߾� ��ġ�� ���������� ����� �� �ֵ��� �ϱ� ���� ���濪��.
    private Vector3[] offset = new Vector3[4];

    private void Awake()
    {
        // ** �÷��̾��� �⺻������ �޾ƿ´�.
        player = GameObject.Find("Player").gameObject;

        // ** �θ�ü�� �޾ƿ´�.
        parent = GameObject.Find("BackGround").transform;

        // ** �÷��̾� �̹����� ����ִ� ������Ҹ� �޾ƿ´�.
        playerController = player.GetComponent<PlayerController>();

        for (int i = 0; i < backgrounds.Length; ++i)
        {
            backgrounds[i] = GameObject.Find("BackGround").transform.GetChild(i).gameObject;

            // ** ���� �̹����� ����ִ� ������Ҹ� �޾ƿ´�.
            spriteRenderers[i] = backgrounds[i].GetComponent<SpriteRenderer>();
        }
    }

    void Start()
    {
        offset[0] = new Vector3(1.0f, 0.0f, 0.0f);
        offset[1] = new Vector3(0.5f, 0.0f, 0.0f);
        offset[2] = new Vector3(0.25f, 0.0f, 0.0f);
        offset[3] = new Vector3(0.0f, 0.0f, 0.0f);

        backgrounds[0].transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        backgrounds[1].transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        backgrounds[2].transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        backgrounds[3].transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        // ** ������ҿ� ���Ե� �̹����� �޾ƿ´�.
        for (int i = 0; i < backgrounds.Length; ++i)
        {
            backgrounds[i] = GameObject.Find("BackGround").transform.GetChild(i).gameObject;
            sprites[i] = spriteRenderers[i].sprite;

            backgrounds[i].transform.position = offset[i];
        }

        // ** ���������� ����.
        endPoint = sprite.bounds.size.x * 0.5f + transform.position.x;

        /*
        Test = new GameObject("Gozmo");
        Test.AddComponent<MyGizmo>();
        Test.transform.position = new Vector3(endPoint, 0.0f, 0.0f);
         */

        // ** ���������� ����.
        exitPoint = -(sprite.bounds.size.x * 0.5f) + player.transform.position.x;
    }

    void Update()
    {
        // ** �̵����� ����
        movemane = new Vector3(
            Input.GetAxisRaw("Horizontal") * Time.deltaTime * Speed + offset.x,
            0.0f, 0.0f);

        // ** singleton
        if(ControllerManager.GetInstance().DirRight)
        {
            transform.position -= movemane;
            endPoint -= movemane.x;
        }

        // ** ������ �̹��� ����
        if (player.transform.position.x + (sprite.bounds.size.x * 0.5f) + 1 > endPoint)
        {
            // ** �̹����� �����Ѵ�.
            GameObject Obj =  Instantiate(this.gameObject);

            // ** ������ �̹����� �θ� �����Ѵ�.
            Obj.transform.parent = parent.transform;

            // ** ������ �̹����� �̸��� �����Ѵ�.
            Obj.transform.name = transform.name;

            if(GameObject.Find("1"))
            {
                print("111");
            }

            // ** ������ �̹����� ��ġ�� �����Ѵ�.
            Obj.transform.position = new Vector3(
                endPoint + 25.0f,
                0.0f, 0.0f);

            // ** ���������� �����Ѵ�.
            endPoint += endPoint + 25.0f;
        }

        // ** ���������� �����ϸ� �����Ѵ�.
        if(transform.position.x + (sprite.bounds.size.x * 0.5f) - 2 < exitPoint)
            Destroy(this.gameObject);
    }
}
