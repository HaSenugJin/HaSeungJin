using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            print("hit");
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    private void PlayerHit()
    {
        if (GetComponent<CapsuleCollider2D>().enabled == false)
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
            print("true");
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
