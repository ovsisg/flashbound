using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerControls playerControls { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerFallState fallState { get; private set; }

    public bool hasGameStarted { get; private set; } = false;
    public bool jumpBuffered { get; private set; } = false;
    public bool isGroundDetected { get; private set; }

    private StateMachine stateMachine;
    private float currentJumpBuffer = 0;

    [Header("Movement Settings")]
    public float moveSpeed;
    public float jumpForce = 5;

    [Header("Jump Buffer Settings")]
    public float jumpBufferTime = 0.2f;

    [Header("Ground Detection")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        playerControls = new PlayerControls();

        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        jumpState = new PlayerJumpState(this, stateMachine, "jumpFall");
        fallState = new PlayerFallState(this, stateMachine, "jumpFall");
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        stateMachine.Initialise(fallState);
    }

    private void Update()
    {
        DetectGround();

        if (!hasGameStarted && Keyboard.current.anyKey.wasPressedThisFrame)
            hasGameStarted = true;

        HandleJumpBuffer();

        stateMachine.UpdateState();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
    }

    public void StartJumpBuffer()
    {
        jumpBuffered = true;
        currentJumpBuffer = jumpBufferTime;
    }

    public void ClearJumpBuffer()
    {
        jumpBuffered = false;
    }

    private void HandleJumpBuffer()
    {
        if (jumpBuffered)
        {
            currentJumpBuffer -= Time.deltaTime;
            if (currentJumpBuffer < 0)
            {
                jumpBuffered = false;
            }
        }
    }

    private void DetectGround()
    {
        isGroundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance, 0));
    }
}
