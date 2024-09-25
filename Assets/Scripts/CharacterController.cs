using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController: MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontalAxis;

    [Header("Movement Settings")]
    public float speed = 2;

    [Header("Jump Settings")]
    public float jumpForce = 10;
    public AudioSource jumpAudioSource;

    [Header("Grounded Check")]
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    private bool isGrounded = false;

    [Header("Coin UI")]
    public CoinUI coinUI;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        Move();
        HandleMoveAnimation();
        FlipCharacter();
        CheckIfGrounded();
        Jump();
    }

    private void Move()
    {
        Vector2 targetVelocity = new Vector2(horizontalAxis * speed, rb.velocity.y);
        rb.velocity = targetVelocity;
    }

    private void HandleMoveAnimation()
    {
        if(horizontalAxis != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FlipCharacter()
    {
        if (horizontalAxis > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalAxis < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            // Do nothing
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpAudioSource.Play();
        }
    }

    private void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
