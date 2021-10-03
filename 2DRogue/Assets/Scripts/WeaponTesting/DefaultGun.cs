using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DefaultGun : GunPickup
{
    private float spreadAmountX;
    private float spreadAmountY;


    private void Start()
    {
        damage = 10f;
        shotSpeed = 20f;
        fireRate = 2f;
        numberOfShots = 1;
        spread = 20f;

    }

    public override void Fire(Transform firePoint)
    {
        spreadAmountX = Random.Range(-spread, spread);
        spreadAmountY = Random.Range(-spread, spread);


        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(spreadAmountX, spreadAmountY, 0);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * shotSpeed, ForceMode2D.Impulse);

        Destroy(bullet, 10f);
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
