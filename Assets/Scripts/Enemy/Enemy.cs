using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Health enemyHealth;
    [SerializeField] int damage;
    [SerializeField] private float speed;
    [SerializeField] private float agroRange;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D enemyRb;
    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, player.transform.position) < agroRange)
        {
            Vector2 dirrection;
            dirrection = player.transform.position - transform.position;
            dirrection.Normalize();
            enemyRb.MovePosition((Vector2)enemyRb.position + dirrection * speed * Time.fixedDeltaTime);
        }
    }
    private void OnEnable()
    {
        enemyHealth.onDeath.AddListener(HandleDeath);

    }
    private void OnDisable()
    {
        enemyHealth.onDeath.RemoveAllListeners();
    }

    void HandleDeath()
    {
        Destroy(gameObject);
    }
}
