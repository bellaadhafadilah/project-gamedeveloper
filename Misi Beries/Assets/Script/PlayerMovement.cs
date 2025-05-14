using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private PlayerController playerController; // Tambahkan PlayerInputActions

    private Vector2 moveInput;
    private bool isJumping = false;

    private enum MovementState { idle, walk, jump, fall, run}

    [Header("Jump Settings")]
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D coll;

    // Tambahkan referensi ke GameManager untuk pause game
    public GameManager gameManager;  // Referensi ke GameManager

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        playerController = new PlayerController(); // Inisialisasi PlayerInputActions
    }

    private void OnEnable()
    {
        playerController.Enable();

        playerController.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerController.Movement.Move.canceled += ctx => moveInput = Vector2.zero;

        playerController.Movement.Jump.performed += ctx => Jump();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    private void Update()
    {
        // Cek apakah permainan sedang dipause
        if (gameManager.isGamePaused)
            return;  // Jangan jalankan pergerakan jika game dipause

        moveInput = playerController.Movement.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Mengatur kecepatan pergerakan pemain
        Vector2 targetVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = targetVelocity;
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        // Menentukan status pergerakan berdasarkan input
        if (moveInput.x > 0f)
        {
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (moveInput.x < 0f)
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // Menentukan status lompat atau jatuh
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        // Mengecek apakah pemain menyentuh tanah
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Jump()
    {
        // Mengecek apakah pemain di tanah dan melakukan lompat
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
