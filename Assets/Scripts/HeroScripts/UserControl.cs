using System.Collections;
using UnityEngine;
public class UserControl : MonoBehaviour
{
    [Header("Ground Check")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _groundCheckRadius = 0.2f;

    [Header("Player Stats")]
    [SerializeField] public PlayerConfig playerConfig;

    [Header("Player Physics")]
    [SerializeField] private Rigidbody2D rbPlayer;
    public bool IsGround { get; private set; }
    public Rigidbody2D Rigidbody => rbPlayer;

    private CapsuleCollider2D playerCollider;
    public float nextTimeJump;

    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;

    [Header("Player State")]

    [Header("Player Visual")]
    public Animator animator { get; private set; }

    private void Awake()
    {
        if (rbPlayer == null)
        {
            rbPlayer = GetComponent<Rigidbody2D>();
        }

        playerCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        horizontalInput = UserInput.Horizontal;
        verticalInput = UserInput.Vertical;

        IsGround = Physics2D.OverlapCircle(_playerTransform.position, _groundCheckRadius, _groundLayer);

    }

    private void FixedUpdate()
    {
    }

    public void DoJump()
    {
        rbPlayer.linearVelocity = new Vector2(rbPlayer.linearVelocity.x, playerConfig.JumpForce);
        nextTimeJump = Time.time + playerConfig.JumpCooldown;
    }

    public bool CanJump()
    {
        return Time.time >= nextTimeJump;
    }

    public void Move(float speed)
    {
        playerConfig.CurrentSpeed = speed;

        float targetSpeed = horizontalInput * playerConfig.CurrentSpeed;
        float currentSpeed = rbPlayer.linearVelocity.x;

        targetSpeed = Mathf.Clamp(targetSpeed, -speed, speed);

        float newSpeed = Mathf.Lerp(
            currentSpeed,
            targetSpeed,
            playerConfig.Smoothing * Time.fixedDeltaTime);

        Debug.Log($"Move | horizontalInput={horizontalInput} | targetSpeed={targetSpeed} | currentSpeed={currentSpeed} | newSpeed={newSpeed}");

        rbPlayer.linearVelocity = new Vector2(newSpeed, rbPlayer.linearVelocity.y);
    }

    public float MoveXValue()
    {
        return Mathf.Abs(rbPlayer.linearVelocity.x);
    }

    public void CharFlip()
    {
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void AnimPlay(string clipName)
    {
        if (string.IsNullOrWhiteSpace(clipName) || animator == null)
        {
            return;
        }

        animator.Play(clipName);
    }

    private void OnDrawGizmosSelected()
    {
        if (_playerTransform == null)
        {
            return;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_playerTransform.position, _groundCheckRadius);
    }
}