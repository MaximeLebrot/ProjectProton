using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{

    public GunPickup equippedGun;
    public Transform firePoint;
    public GameObject defaultGun;

    private float lastFire = 0f;

    private void Start()
    {
        defaultGun.SetActive(false);
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > (equippedGun.getFireRate() / 10) + lastFire)
        {
            for (int i = 0; i < equippedGun.getNumberOfShots(); i++)
            {
                equippedGun.Fire(firePoint);
            }
            lastFire = Time.time;
        }
    }

    public void DropEquippedGun()
    {
        GameObject equippedGunClone = equippedGun.getGameObject();

        equippedGunClone.transform.position = transform.position;
        equippedGunClone.SetActive(true);
    }


    public void NewGunPickup(GunPickup gunPickup)
    {
        equippedGun = gunPickup;
    }

    public GunPickup getEquippedGun()
    {
        return equippedGun;
    }
}
