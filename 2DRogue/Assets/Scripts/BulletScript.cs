using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject hitEffect;

    private Vector2 lastPos;
    private Vector2 curPos;
    private Vector2 playerPos;

    /*void Start()
    {
        transform.localScale = new Vector2(GameController.BulletSize, GameController.BulletSize);
    }

    void Update()
    {
        curPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, 5f * Time.deltaTime);
        if (curPos == lastPos)
        {
            Destroy(gameObject);
        }
            
        lastPos = curPos;
   Y }
    

    public void GetPlayer(Transform player)
    {
        playerPos = player.position;
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }
        else if (col.tag != "Bullet")
        {
            GameController.DamagePlayer(1);
            Destroy(gameObject);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision) // Något händer när man träffar något
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }*/
}
