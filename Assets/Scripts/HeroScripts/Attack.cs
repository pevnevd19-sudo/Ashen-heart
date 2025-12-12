using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange = 5;
    [SerializeField]private LayerMask enemyLayers;
    private FirstSword weapon;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Attacks();
        }
    }

    void Attacks()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

       foreach(Collider2D enemie in hitEnemies)
        {
            enemie.GetComponent<Health>();
            if(enemie!= null)
            {
            }
            else
            {
                return;
            }
        }
    }
}

