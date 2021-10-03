using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunDrop : MonoBehaviour
{
    public GameObject riflePrefab;
    public GameObject sniperPrefab;

    private GameObject spawnedGun;

    private void OnEnable()
    {
        int gunType = Random.Range(1, 3);
        if (gunType == 2)
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
