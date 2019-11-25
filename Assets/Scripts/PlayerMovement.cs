using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController2D controller; //controls crouching, jumping, walking and checking if the player is touching hte ground
    float horizontalMove = 0f;
    public float movementSpeed = 15f;

    //Checking for player movements jumping and crouching aside from walking
    bool jump = false;
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            //Debug.Log("derp"); 
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }  
    }

    void FixedUpdate()
    {
        //move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
       
        jump = false;

        //transform.Translate(new Vector2(horizontalMove * Time.deltaTime, 0));
    }
}
