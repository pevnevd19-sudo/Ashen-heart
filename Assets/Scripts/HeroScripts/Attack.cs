using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    [SerializeField]private Transform attackPoint;     // Точка, откуда идет удар
    [SerializeField]private float attackRange = 0.5f;  // Радиус удара
    private LayerMask enemyLayers;     // Какие объекты считаются врагами
    public int attackDamage = 20;     // Урон

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Нажатие клавиши удара
        {
            Attacks();
        }
    }

    void Attacks()
    {

        // Проверяем врагов в радиусе удара
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().DamageHero(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

