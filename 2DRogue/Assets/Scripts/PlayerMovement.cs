using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Camera cam;
    public Rigidbody2D rb;
    public Joystick joystick;
    public Joystick joystickDir;
    private float turnSpeed = 10000f; 

    void Update()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        float rotationHorizontal = joystickDir.Horizontal;
        float rotationVertical = joystickDir.Vertical;

        float headingAngle = Mathf.Atan2(moveVertical, moveHorizontal) * Mathf.Rad2Deg;
        if (headingAngle < 0) headingAngle += 360f;


        float rotation = Mathf.Atan2(rotationVertical, rotationHorizontal) * Mathf.Rad2Deg; // gör så att du följer joystickDir
        Quaternion whereUPoint = Quaternion.Euler(0f, 0f, rotation - 90f); // Vilket håll du pekar åt.
        float angleDiff2 = Quaternion.Angle(transform.rotation, whereUPoint); // DEN HÄR GÖR ATT MAN KAN ROTERA I ROTERINGS


        Quaternion newHeading = Quaternion.Euler(0f, 0f, headingAngle-90f); //finns för att skapa röelsen. du kan gå.
        float angleDiff = Quaternion.Angle(transform.rotation, newHeading); //Rörelse

        if ((angleDiff2 > 1.0f) && (rotationHorizontal != 0f || rotationVertical != 0f)) // Turning
        {
            //Debug.Log("Turning");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, whereUPoint, turnSpeed * Time.deltaTime);
        }
        

        if (moveHorizontal != 0f || moveVertical != 0f) // GÖR SÅ ATT man RÖR SIG OM MAN DRAR I VÄNSTER SPAKEN
        {
            transform.position += new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, moveVertical * moveSpeed * Time.deltaTime, 0);
        }

       
        else // OM MAN STÅR STILL 
        {
            //Debug.Log("Stationary");
            // LÄGG TILL IDLE ANIMATION ELLER NÅT... LJUD KANSKE?!?!?!?!?
        }
    }

    


   


}
