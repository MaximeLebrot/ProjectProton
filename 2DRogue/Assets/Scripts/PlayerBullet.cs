using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBullet : MonoBehaviour
{

    //public GameObject hitEffect;
    private float damage;

    private void Awake()
    {
        GameObject player = GameObject.Find("Player");
        Shooting shooting = player.GetComponent<Shooting>();
        damage = shooting.getEquippedGun().damage;
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            //hitEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(hitEffect, 3f);
            Destroy(gameObject);

        }else if(col.tag == "Boss")
        {
           
            
            col.gameObject.GetComponent<BossController>().TakeDamage(damage);
            Destroy(gameObject);


        }
        else if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }
        /*else if (col.tag != "Bullet" && col.tag != "Player")
        {
            //hitEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(hitEffect, 3f);
            Destroy(gameObject);
        }*/


    }
}

