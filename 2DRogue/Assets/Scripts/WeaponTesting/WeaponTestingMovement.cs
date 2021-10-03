using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTestingMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Camera cam;
    public Rigidbody2D rb;
    public static Vector2 lookDir;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public Vector2 getLookDir()
    {
        return lookDir;
    }
}
