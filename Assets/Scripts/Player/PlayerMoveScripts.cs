using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScripts : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private float jumpForce;

    private Rigidbody2D rb;
    private Animator animator;

    private bool Grounded;
    private bool isJump;
    private bool isGameStared;
    private bool moveLeft;
    private bool moveRight;

    private AudioSource jumpSound;
    private PlayerControls playerControl;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        jumpSound = GetComponent<AudioSource>();

        moveLeft = false;
        moveRight = false;
    }
    private void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(x * speed, rb.velocity.y);

        ////Flip player when moving left - righth
        //if (x > 0.01f)
        //{ transform.localScale = Vector3.one; }
        //else if (x < -0.01f)
        //{ transform.localScale = new Vector3(-1, 1, 1); }

        //Jump
        //if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        //{
        //    jumpSound.Play();
        //    Jump(jumpForce);
        //}

        // float MoveInput = playerControl.PlayerControl.Movement.ReadValue<float>();
        // float JumpInput = playerControl.PlayerControl.Jump.ReadValue<float>();

        // jumpForce = JumpInput * speed * Time.deltaTime;

        // Movement(MoveInput);
        // if (JumpInput > 0 && Grounded)
        // {
        //     Jumping(jumpForce);
        // }

        
        if (moveLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            FlipGFX(rb.velocity.x);
        }
        if (moveRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            FlipGFX(rb.velocity.x);
        }
        //animation of player
        animator.SetBool("Walk", rb.velocity.x != 0);
        animator.SetBool("Grounded", Grounded);
    }
    public void Jumping(float force)
    {
        isJump = true; Grounded = false;

        rb.velocity = new Vector2(rb.velocity.x, speed);
        rb.AddForce(new Vector2(0f, force));

        animator.SetTrigger("Jump");
        jumpSound.Play();
    }
    public void Movement(float moveInput)
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        FlipGFX(moveInput);
    }
    public void FlipGFX(float x)
    {
        if (x > 0.01f)
        { transform.localScale = Vector3.one; }
        else if (x < -0.01f)
        { transform.localScale = new Vector3(-1, 1, 1); }
    }
    public void ButtonJump()
    {
        jumpForce = 1 * speed * Time.deltaTime;

        if (Grounded)
        {
            Jumping(jumpForce);
        }
    }
    public void ButtonLeft()
    {
        moveLeft = true;
    }
    public void ButtonRight()
    {
        moveRight = true;
    }
    public void StopMoveing()
    {
        moveLeft = false;
        moveRight = false;
        rb.velocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { Grounded = true;}
    }
}
