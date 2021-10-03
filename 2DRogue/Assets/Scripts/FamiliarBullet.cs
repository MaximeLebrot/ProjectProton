using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamiliarBullet : MonoBehaviour
{
    private float damage;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);

        }
        else if (col.tag == "Boss")
        {
            col.gameObject.GetComponent<BossController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
