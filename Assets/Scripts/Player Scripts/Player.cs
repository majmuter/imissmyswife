using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public int facingDirection = 1; // Stores the value of the direction player is facing

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private bool isDrinking;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        Flip();
        SetAnimation(moveInput);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // Checks flipping and flips the player
    void Flip()
    {
        if (moveInput > 0.1f)
        {
            facingDirection = 1;
        }
        else if (moveInput < -0.1f)
        {
            facingDirection = -1;
        }

        transform.localScale = new Vector3(facingDirection, 1, 1);

    }

    private void SetAnimation(float moveInput)
    {
        animator.SetBool("isMoving", Mathf.Abs(moveInput) > 0.01f);
        animator.SetBool("isGrounded", isGrounded);
        /*
        if (isDrinking)
        {
            return;
        }

        if (isGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("Player_Idle"); //idle animation
            }
            else
            {
                animator.Play("Player_Move");
            }
        }
        else
        {
            if (rb.linearVelocityY > 0)
                animator.Play("Player_JUmp");
        }
        */
    }

    /*public void StartDrinking()
    {
        if (isDrinking)
        {
            return;
        }

        isDrinking = true;
        animator.Play("Player_drink", 0, 0f);
    }

    public void StopDrinking()
    {
        isDrinking = false;
    }*/
}

