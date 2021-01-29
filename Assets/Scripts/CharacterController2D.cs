using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    bool onGround = true;
    bool jump = false;

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
        
        rigidBody2D.AddForce(new Vector2(run, 0));

        Debug.Log(onGround);

        Vector2 pos = transform.position;

        

        if (onGround && jump)
        {
            Vector2 jumpDir = Vector2.zero;
            RaycastHit2D downHit = Physics2D.Raycast(pos, Vector2.down, 1.1f); // TODO mask this with only walls
            
            if (downHit.collider != null)
            {
                jumpDir += Vector2.up;
            }

            else if (Mathf.Abs(moveInput) > 0.5f)
            {
                RaycastHit2D leftHit = Physics2D.Raycast(pos, Vector2.left, 0.6f); // TODO mask this with only walls
                RaycastHit2D rightHit = Physics2D.Raycast(pos, Vector2.right, 0.6f); // TODO mask this with only walls

                if (leftHit.collider != null)
                {
                    jumpDir += Vector2.right;
                    if(jumpDir.y < 0.1f)
                    {
                        jumpDir.y = 1.0f;
                    }
                }
                else if (rightHit.collider != null)
                {
                    jumpDir += Vector2.left;
                    if (jumpDir.y < 0.1f)
                    {
                        jumpDir.y = 1.0f;
                    }
                }




            }



            jump = false;
            rigidBody2D.AddForce(jumpDir * JumpForce, ForceMode2D.Impulse);
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 playerInput = context.ReadValue<Vector2>();

        // Debug.Log("Move!" + playerInput.x);
        moveInput = playerInput.x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        jump = context.ReadValueAsButton();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        onGround = true;
        Vector3 colliderPos = collision.gameObject.transform.position;

        List<ContactPoint2D> contacts = new List<ContactPoint2D>();

        collision.GetContacts(contacts);

        if (colliderPos.x < transform.position.x)
        {

        }
    }

}
