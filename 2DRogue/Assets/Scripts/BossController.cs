using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle,
    Follow,
    Die,
    Attack
};

public enum BossType
{
    Melee,

    Ranged
};

public class BossController : MonoBehaviour
{

    GameObject player;
    

    public BossState currState = BossState.Idle;
    public BossType enemyType;

    public float range;
    public float speed;
    public float attackRange;
    public float coolDown;
    public GameObject bulletPrefab;
    public float health = 100f;
    public GameObject gunSpawner;
    public GameObject floorExit;

    private bool chooseDir = false;
    private Vector3 randomDir;
    private bool coolDownAttack = false;
    public bool notInRoom = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        switch (currState)
        {
            case (BossState.Follow):
                Follow();
                break;
            case (BossState.Die):

                break;
            case (BossState.Attack):
                Attack();
                break;
        }

        if (!notInRoom)
        {

            if (isPlayerInRange(range) && currState != BossState.Die)
            {
                currState = BossState.Follow;
            }

            if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {
                currState = BossState.Attack;
            }
        }
        else
        {
            currState = BossState.Idle;
        }
    }

    private bool isPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }

    private IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Attack()
    {
        if (!coolDownAttack)
        {         
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;     
            bullet.GetComponent<EnemyBullet>().GetPlayer(player.transform);
            StartCoroutine(CoolDown());
            
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        gunSpawner.SetActive(true);
        floorExit.SetActive(true);
        RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
        Destroy(gameObject);
    }

}
