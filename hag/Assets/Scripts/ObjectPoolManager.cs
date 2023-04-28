using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager
{
    public static ObjectPoolManager GetInstence { get; } = new ObjectPoolManager();
    private ObjectPoolManager() { }
    private Dictionary<string, Stack<GameObject>> DisableList = new Dictionary<string, Stack<GameObject>>();

    public GameObject GetObject(string key)
    {
        Stack<GameObject> stack;
        GameObject prefab = null;
        if (DisableList.TryGetValue(key, out stack) && stack.Count > 0)
        {
            prefab = stack.Pop();
        }
        else
        {
            prefab = pre.GetInstence.getPrefnbByName(key);
            

            if (prefab == null)
                return null;

            prefab.name = key;
        }

        prefab.SetActive(true);
        //Object.GetComponent<>();
        return prefab;
    }

    public void returnObject(GameObject Obj)
    {
        if(DisableList.ContainsKey(Obj.name))
        {
            DisableList[Obj.name].Push(Obj);
        }
        else
        {
            Stack<GameObject> stack = new Stack<GameObject>();

            stack.Push(Obj);
            DisableList.Add(Obj.name, stack);
        }
    }
}
