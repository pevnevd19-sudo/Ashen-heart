using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    private UserControl player;
    private Rigidbody2D rb;
    [SerializeField] private float stepBySec;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<UserControl>();
        stepBySec = 1.5f;
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if ( transform.position.x > player.transform.position.x + 1 || transform.position.x < player.transform.position.x - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, stepBySec * Time.deltaTime);
        }

    }
}
