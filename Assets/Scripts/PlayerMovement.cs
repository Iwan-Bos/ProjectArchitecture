using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float walkSpeed = 12f;
    public float sprintingSpeed = 24f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // stamina bar stuff ↓↓
    public float staminaFactor;
    public GameObject staminaBar;
    private UnityEngine.UI.Slider staminaSlider;
    private float staminaTimer = 0f;
    public float staminaTimerValue;

    private void Start() 
    {
        staminaSlider = staminaBar.GetComponent<UnityEngine.UI.Slider>();
    }


    // Update is called once per frame
    void Update()
    {
        // stuff
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) { velocity.y = -2f; }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right  * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        // jumping
        if(isGrounded && Input.GetButtonDown("Jump")) {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // stamina timer
        staminaTimer -= Time.deltaTime;
        Debug.ClearDeveloperConsole();
        Debug.Log(staminaTimer);

        // when on ground
        if (isGrounded) 
        {
            // when shift and w is held
            if (Input.GetKey("left shift") && Input.GetKey("w")) {
            
                // sprint
                speed = sprintingSpeed; 
                
                // reduce stamina
                staminaSlider.value -= staminaFactor * Time.deltaTime ;
            }
            
            // when not holding shif and w
            else {

                // walk
                speed = walkSpeed;

                // wait && regen until shift is held again
                if (staminaTimer <= 0) {
                    
                    // regen stamina
                    staminaSlider.value += staminaFactor * Time.deltaTime;
                }
            }
        }

        // moving 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
} 