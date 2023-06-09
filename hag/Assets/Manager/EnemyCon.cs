using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon : MonoBehaviour
{
    private void Initialized()
    {
        transform.position = new Vector3(0.0f, 10.0f, 0.0f);
    }

    private void Start()
    {
        Initialized();
    }

    private void OnEnable()
    {
        Initialized();
    }

    private void OnDisable()
    {
        ObjectPoolManager.GetInstence.returnObject(this.gameObject);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }
}
