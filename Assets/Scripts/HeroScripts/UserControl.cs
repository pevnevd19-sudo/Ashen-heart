using UnityEngine;

public class UserControl : MonoBehaviour
{
    public PlayerConfig playerConfig;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    private Rigidbody2D rbPlayer;
    private bool IsGround;
    private float horizontalInput;
    public IPlayerState currentState;
    public IdleState idleState;
    public WalkState walkState;
    public RunState runState;
    public Animator animator;
    public int normalSpeed;
    public int minSpeed;

    private void Awake()
    {
        // playerConfig._speed = 6;
        idleState = new IdleState(this);
        walkState = new WalkState(this);
        runState = new RunState(this);
        normalSpeed = 6;
        minSpeed = 0;

    }

    void Start()
    {
        ChangeState(idleState);
        rbPlayer = GetComponent<Rigidbody2D>();

        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (currentState != null) currentState.Update();
        IsGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Move();
        CharFlip();
    }
    private void Jump()
    {
        rbPlayer.linearVelocity = new Vector2(rbPlayer.linearVelocity.x, playerConfig._jumpForce);
    }

    public void Move()
    {
        horizontalInput = UserInput.Horizontal;
        float targetSpeed = horizontalInput * playerConfig._speed;
        targetSpeed = Mathf.Clamp(targetSpeed, -playerConfig._maxSpeed, playerConfig._maxSpeed);
        float currentSpeed = rbPlayer.linearVelocity.x;
        float newSpeed = Mathf.Lerp(currentSpeed, targetSpeed, playerConfig.smoothing * Time.fixedDeltaTime);
        rbPlayer.linearVelocity = new Vector2(newSpeed, rbPlayer.linearVelocity.y);
    }
    public float IsMoving()
    {
        float HorizontalAbs = Mathf.Abs(rbPlayer.linearVelocity.x);
        return HorizontalAbs;
    }
    public void CharFlip()
    {
        if (horizontalInput > 0) transform.localScale = new Vector3(1, 1, 1);
        if (horizontalInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    public void ChangeState(IPlayerState playerState)
    {
        if (currentState == playerState) return;

        if (currentState != null) currentState.Exit();

        currentState = playerState;
        if (currentState != null) currentState.Enter();
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
