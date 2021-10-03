using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    private float lastFire;
    private GameObject player;
    private float lastOffsetX;
    private float lastOffsetY;
    private float rotationHorizontal;
    private float rotationVertical;
    private float moveHorizontal;
    private float moveVertical;

    public FamiliarData familiar;
    public Transform firePoint;
    public Joystick joystickDir;
    public Joystick joystick;
    public float turnSpeed = 100f;
    public float fireRate = 0.5f;
    public float shotSpeed = 10f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        rotationHorizontal = joystickDir.Horizontal;
        rotationVertical = joystickDir.Vertical;
        moveHorizontal = joystick.Horizontal;
        moveVertical = joystick.Vertical;
        float rotation = Mathf.Atan2(rotationVertical, rotationHorizontal) * Mathf.Rad2Deg;
        Quaternion whereUPoint = Quaternion.Euler(0f, 0f, rotation - 90f);
        float angleDiff2 = Quaternion.Angle(transform.rotation, whereUPoint);
        if ((angleDiff2 > 1.0f) && (rotationHorizontal != 0f || rotationVertical != 0f))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, whereUPoint, turnSpeed * Time.deltaTime);
        }
        Shoot();
        if(moveHorizontal != 0 || moveVertical != 0)
        {
            float offsetX = (moveHorizontal < 0 ? Mathf.Floor(moveHorizontal) : Mathf.Ceil(moveHorizontal));
            float offsetY = (moveVertical < 0 ? Mathf.Floor(moveVertical) : Mathf.Ceil(moveVertical));

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, familiar.speed * Time.deltaTime);
            lastOffsetX = offsetX;
            lastOffsetY = offsetY;
        }
        else
        {
            if(!(transform.position.x < lastOffsetX + 0.5f) || !(transform.position.y < lastOffsetY + 0.5f))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - lastOffsetX, player.transform.position.y - lastOffsetY), familiar.speed * Time.deltaTime);
            }
        }
    }
    void Shoot()
    {
        if ((rotationHorizontal != 0f || rotationVertical != 0f) && Time.time > (fireRate / 10) + lastFire)
        {
            for (int i = 0; i < 1; i++)
            {
                InstantiateProjectile(new Vector3(0f, 0f, 0f));
            }
            lastFire = Time.time;
        }
    }

    void InstantiateProjectile(Vector3 offsetRotaion)
    {
        GameObject bullet = Instantiate(familiar.bulletPrefab, firePoint.position, transform.rotation) as GameObject;
        bullet.transform.Rotate(offsetRotaion);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.up * shotSpeed, ForceMode2D.Impulse);

        Destroy(bullet, 10f);
    }
}
