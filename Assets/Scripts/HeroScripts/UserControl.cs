using System.Collections;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    public PlayerConfig playerConfig;

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float jumpCooldown;

    private float nextTimeJump;
    [SerializeField] private Rigidbody2D rbPlayer;
    private CapsuleCollider2D playerCollider;
    private bool IsGround;

    private float horizontalInput;
    private float verticalInput;

    public StateMachine playerState;
    public IdleState idleState;
    public WalkState walkState;
    public RunState runState;
    public JumpState jumpState;
    public FallState fallState;
    public CrouchIdleState crouchIdleState;
    public CrouchWalkState crouchWalkState;

    public Animator animator;

    public int normalSpeed;
    public int minSpeed;


    private void Awake()
    {
        playerState = new StateMachine();
        idleState = new IdleState(this);
        walkState = new WalkState(this);
        runState = new RunState(this);
        jumpState = new JumpState(this);
        fallState = new FallState(this);
        crouchIdleState = new CrouchIdleState(this);
        crouchWalkState = new CrouchWalkState(this);

        normalSpeed = 6;
        minSpeed = 0;
        jumpCooldown = 1.36f;
    }

    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
        playerState.ChangeState(idleState);
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        float yVelocity = Mathf.Abs(rbPlayer.linearVelocity.y);
        if (IsGround) yVelocity = 0;
        playerState.Update();
        IsGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        Jump();
        Fall();
        Crouch();
    }
    private void FixedUpdate()
    {
        Move();
        CharFlip();
    }
    private void Jump()
    {
        if (UserInput.Vertical > 0.2 && IsGround && CanJump())
        {
            playerState.ChangeState(jumpState);
            verticalInput = UserInput.Vertical;
            if (verticalInput > 0) verticalInput = 1;
            rbPlayer.linearVelocity = new Vector2(rbPlayer.linearVelocity.x, verticalInput * playerConfig._jumpForce);
            nextTimeJump = Time.time + jumpCooldown;
        }
    }

    private void Crouch()
    {
        verticalInput = UserInput.Vertical;
        float sizeColliderY = playerCollider.size.y;
        sizeColliderY = 0.8f;
        if (IsMoving() <= 0 && verticalInput < 0)
        {
            playerState.ChangeState(crouchIdleState);
        }
        if (IsMoving() > 0 && verticalInput < 0)
        {
            playerState.ChangeState(crouchWalkState);
        }
        
    }
    private void Fall()
    {
        if (rbPlayer.linearVelocity.y < -0.5f)
        {
            float linearVelocityX = rbPlayer.linearVelocity.x;
            playerState.ChangeState(fallState);
            linearVelocityX = 0;
        }
    }
    public bool isFall()
    {
        if (rbPlayer.linearVelocity.y < -1f)
        {
            return true;
        }
        return false;
    }
    private bool CanJump()
    {
        return Time.time >= nextTimeJump;
    }

    public void Move()
    {
        horizontalInput = UserInput.Horizontal;
        float targetSpeed = horizontalInput * playerConfig._speed;
        targetSpeed = Mathf.Clamp(targetSpeed, -playerConfig._maxSpeed, playerConfig._maxSpeed);
        float currentSpeed = rbPlayer.linearVelocity.x;
        float newSpeed = Mathf.Lerp(currentSpeed, targetSpeed, playerConfig.smoothing * Time.fixedDeltaTime);
        rbPlayer.linearVelocity = new Vector2(newSpeed, rbPlayer.linearVelocity.y);
        if (UserInput.Horizontal <= 0) currentSpeed = 0; 
        if (IsMoving() > 0.5f) playerState.ChangeState(walkState);
        

    }
    public bool IsWalk()
    {
        if (rbPlayer.linearVelocity.x >= 0.5f)
        {
            return true;
        }
        return false;
    }
    public float IsMoving()
    {
        float HorizontalAbs = Mathf.Abs(rbPlayer.linearVelocity.x);
        return HorizontalAbs;
    }
    public bool IsGrounded()
    {
        return IsGround;
    }

    public void CharFlip()
    {
        if (horizontalInput > 0) transform.localScale = new Vector3(1, 1, 1);
        if (horizontalInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }


    public void SetSpeed(int speed)
    {
        playerConfig._speed = speed;
        return;
    }
    private void OnDrawGizmosSelected()
    {
        if (_groundCheck)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
        }
    }

}
