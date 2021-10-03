using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public GameObject riflePrefab;
    public GameObject sniperPrefab;

    private GameObject spawnedGun;
    private GunPickup newGun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            spawnGun();
            
        }
    }

    private void spawnGun()
    {
        //Gun gun = ScriptableObject.CreateInstance("Gun") as Gun;
        //gun.Init();

        //GunPickup newGun = new GunPickup();
        //gunPrefab = newGun;
        int gunType = Random.Range(1, 3);
        if(gunType == 2)
        {
            spawnedGun = Instantiate(riflePrefab, transform.position, transform.rotation);
        }
        else
        {
            spawnedGun = Instantiate(sniperPrefab, transform.position, transform.rotation);
        }

        //GunPickup newGun = spawnedGun.GetComponent<GunPickup>().SetNewGun(newGun);
        //newGun.setStats();
        
        Destroy(gameObject);
    }




}
