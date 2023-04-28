using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pre
{
    //�ν��Ͻ� ����
    public static pre GetInstence { get; } = new pre();

    //������ �����
    //List<GameObject>>
    private Dictionary<string, GameObject> prototypeObjectList = new Dictionary<string, GameObject>();

    private pre()
    {
        //�����͸� �ҷ��´�.
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs");

        //�ҷ��� �����͸� Dictionary�� �����Ѵ�.
        foreach (GameObject element in prefabs)
            prototypeObjectList.Add(element.name, element);
    }

    //�ܺο��� �������� Prefab�� ���� �� �� �ֵ��� Getter�� ����.
    public GameObject getPrefnbByName(string key)
    {
        //���࿡ key�� �����Ѵٸ� ���� ��ü�� ��ȯ�ϰ�
        if (prototypeObjectList.ContainsKey(key))
            return GameObject.Instantiate(prototypeObjectList[key]);

        //�׷��� ���������� null�� ��ȯ
        return null;
    }
}