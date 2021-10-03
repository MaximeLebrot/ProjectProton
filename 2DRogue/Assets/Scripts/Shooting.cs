using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //private bool canShoot = true;
    //private float angle;
    //private Vector2 lookDir;
    //private float randomNumX, randomNumY;
    private float lastFire = 0f;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GunPickup equippedGun;
    public GameObject defaultGun;

    public Joystick joystickDir; // aktiverar joystick höger som heter joystickDIR
    float rotationHorizontal;  // Definierar variabler som gör det möjligt att nå joystickDirs rotation senare i scriptet.
    float rotationVertical;  // Definierar variabler som gör det möjligt att nå joystickDirs rotation senare i scriptet.

    private void Start()
    {
        
    }


    void Update()
    {
        rotationHorizontal = joystickDir.Horizontal; //talar om att du rör på höger joystick. Ligger i update
        rotationVertical = joystickDir.Vertical;// för att man kan nå dem i hela scriptet då. Går att lägga någon annanstans.

        if((rotationHorizontal != 0f || rotationVertical != 0f) && Time.time > (equippedGun.fireRate / 10) + lastFire){

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
