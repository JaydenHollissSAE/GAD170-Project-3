using System.Collections;
using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class CameraMovement : MonoBehaviour
{
    // INSTRUCTIONS
    // This script must be on an object that has a Character Controller component.
    // It will add this component if the object does not already have it.
    //    This is done by line 4: "[RequireComponent(typeof(CharacterController))]"
    //
    // Also, make a camera a child of this object and tilt it the way you want it to tilt.
    // The mouse will let you turn the object, and therefore, the camera.

    // These variables (visible in the inspector) are for you to set up to match the right feel
    public float speed = 12f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float yaw = 0.0f;
    public float pitch = 0.0f;

    // This must be linked to the object that has the "Character Controller" in the inspector. You may need to add this component to the object
    public CharacterController controller;
    private Vector3 velocity;

    // Customisable gravity
    public float gravity = -20f;

    // Tells the script how far to keep the object off the ground
    public float groundDistance = 0.4f;

    // So the script knows if you can jump!
    private bool isGrounded;
    private bool doubleJump;

    // How high the player can jump
    public float jumpHeight = 2f;

    private void Start()
    {
        // If the variable "controller" is empty...
        if(controller == null) //Checks if the game's controller is attached.
        {
            // ...then this searches the components on the gameobject and gets a reference to the CharacterController class
            controller = GetComponent<CharacterController>(); //Sets the game's controller.
        }
    }
 
    private void Update()
    {
        // These lines let the script rotate the player based on the mouse moving
        yaw += speedH * Input.GetAxis("Mouse X"); //Sets yaw based on the player's mouse left and right movement.
        pitch -= speedV * Input.GetAxis("Mouse Y"); //Sets pitch based on the player's mouse up and down movement.

        // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
        float x = Input.GetAxis("Horizontal"); //Gets the current horizontal postion.
        float z = Input.GetAxis("Vertical"); //Gets the current vertical postion.

        // Let the player jump if they are on the ground and they press the jump button
        if (Input.GetButtonDown("Jump") && isGrounded || Input.GetButtonDown("Jump") && doubleJump) //Checks if the player is grounded and has pressed jump or if it has a double jump and pressed jump.
        {
            if (doubleJump) //Checks if a doubleJump is met.
            {
                doubleJump = false; //Sets doubleJump to false.
            }
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); //Moves the player up to jump.
        }

        // Rotate the player based off those mouse values we collected earlier
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f); //Rotates the player based on their mouse position.
 
        // This is stealing the data about the player being on the ground from the character controller
        isGrounded = controller.isGrounded; //Sets isGrounded based on the player's postion.
        if (isGrounded ) //Checks if isGrounded is met.
        {
            doubleJump = true; //Sets doubleJump to true.
        }
 
        if (isGrounded && velocity.y < 0) //Checks if the player is grounded and not moving up.
        {
            velocity.y = -2f; //Removes all up momentum from the player.
        }
 
        // This fakes gravity!
        velocity.y += gravity * Time.deltaTime; //Fakes gravity based on time and gravity values acting on player momentum.

        // This takes the Left/Right and Forward/Back values to build a vector
        Vector3 move = transform.right * x + transform.forward * z; //Uses the player's Left/Right and Forward/Back positions to give a movement vector.

        // Finally, it applies that vector it just made to the character
        controller.Move(move * speed * Time.deltaTime + velocity * Time.deltaTime); //Moves the player based on its current position, movement and speed.
    }
}