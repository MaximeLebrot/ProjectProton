using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RifleGun : GunPickup
{
    private float spreadAmountX;
    private float spreadAmountY;

    public override void Fire(Transform firePoint)
    {

        if (numberOfShots == 1)
        {
            spreadAmountX = Random.Range(-spread, spread);
            spreadAmountY = Random.Range(-spread, spread);
        }
        else
        {
            spreadAmountX = Random.Range(-spread - 10, spread + 10);
            spreadAmountY = Random.Range(-spread - 10, spread + 10);
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(new Vector3(spreadAmountX, spreadAmountY, 0));

        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(bullet.transform.up * shotSpeed, ForceMode2D.Impulse);

        Destroy(bullet, 10f);
    }

    private void Awake()
    {
        damage = Random.Range(5, 16);
        shotSpeed = Random.Range(10, 31);
        fireRate = Random.Range(1, 6);
        numberOfShots = Random.Range(1, 4);
        spread = Random.Range(10, 51);

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
