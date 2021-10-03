using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GunPickup : MonoBehaviour
{
    public float damage;
    public float shotSpeed;
    public float fireRate;
    public int numberOfShots;
    public float spread;
    public GameObject bulletPrefab;

    private float pickupCooldown = 5f;
    private float lastPickup = 0f;


    public GunPickup()
    {
        
    }

    public abstract void Fire(Transform firePoint);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.R))
        if(collision.tag.Equals("Player") &&  Time.time > pickupCooldown + lastPickup )
        {
            GameObject player = GameObject.Find("Player");
            Shooting shooting = (Shooting)player.GetComponent(typeof(Shooting));

            shooting.DropEquippedGun();
            shooting.NewGunPickup(this);
            gameObject.SetActive(false);
            lastPickup = Time.time;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        lastPickup = 0f;
    }

    public float getDamage()
    {
        return damage;
    }

    public float getShotSpeed()
    {
        return shotSpeed;
    }

    public float getFireRate()
    {
        return fireRate;
    }

    public int getNumberOfShots()
    {
        return numberOfShots;
    }

    public float getSpread()
    {
        return spread;
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }



}
