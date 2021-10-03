using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{

    public float shotSpeed;
    public float fireRate;
    public int numberOfShots;
    public float spread;
    public Sprite sprite;

    public void Init()
    {
        shotSpeed = Random.Range(10, 31);
        fireRate = Random.Range(1, 6);
        numberOfShots = Random.Range(1, 4);
        spread = Random.Range(10, 51);
    }

    // Start is called before the first frame update
    void Awake()
    {
        
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
}
