using System.Threading;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;
    // Referecia al RidigBody del Character;
    Rigidbody2D rb2D;

    //Variables para salto mejorado
    public bool betterJump = false;
    
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    // Variable que cambia el personaje hacia la derecha o izquierda
    public SpriteRenderer spriteRenderer;

    //Referencia al Animator del Character
    public Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Movement jump
        if (Input.GetKey("space"))
        {
            if(CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
            else 
            {
                if (Input.GetKeyDown("space")){
                    if(canDoubleJump)
                    {   
                        animator.SetBool("isDoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }

        if(!CheckGround.isGrounded)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
        if(CheckGround.isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJump", false);
            animator.SetBool("isFalling", false);
        }

        if(rb2D.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
        } 
        else if(rb2D.velocity.y > 0)
        {
            animator.SetBool("isFalling", false);
        }
    }
    void FixedUpdate()
    {         
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        } 
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else 
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("isRunning", false);
        }

        
        if(betterJump)
        {
            if(rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if(rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }


    }
}
