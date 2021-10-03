using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGun : GunPickup
{

    public override void Fire(Transform firePoint)
    {   

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(bullet.transform.up * shotSpeed, ForceMode2D.Impulse);

        Destroy(bullet, 10f);
    }

    void Awake()
    {
        damage = Random.Range(15, 31);
        shotSpeed = Random.Range(20, 36);
        fireRate = Random.Range(6, 10);
        numberOfShots = 1;
    }

    /* private void OnTriggerStay2D(Collider2D collision)
     {
         if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.R))
         {   
             GameObject player = GameObject.Find("Player"); 
             Shooting2 shooting2 = (Shooting2)player.GetComponent(typeof(Shooting2));

             shooting2.DropEquippedGun(); 
             shooting2.NewGunPickup(this);
             gameObject.SetActive(false);
         }
     }
   */


}
