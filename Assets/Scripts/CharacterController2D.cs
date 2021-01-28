using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    bool onGround = true;
    
    float moveCooldown = 0;
    float moveInput = 0;

    public float JumpForce = 2;
    public float RunSpeed = 2;

    PhysicsMaterial2D staticFriction;
    PhysicsMaterial2D dynamicFriction;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float run = moveInput * Time.deltaTime * RunSpeed;

        rigidBody2D.sharedMaterial = Mathf.Abs(moveInput) > 0.01f ? dynamicFriction : staticFriction;
        
        Debug.Log(rigidBody2D.sharedMaterial);
        rigidBody2D.AddForce(new Vector2(run, 0));

    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 playerInput = context.ReadValue<Vector2>();

        Debug.Log("Move!" + playerInput.x);
        moveInput = playerInput.x;

        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(onGround && context.ReadValueAsButton())
        {
            rigidBody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            onGround = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

}
