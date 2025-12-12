using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField]private float maxHealth=100f;
    [SerializeField] public float currentHealth;
    public UnityEvent onDeath;
    [SerializeField] private Image healthbar;
    [SerializeField]GameObject objects;

    public void IsDamaged(float damage)
    {
        currentHealth -= damage;
        healthbar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            onDeath.Invoke();
            objects.IsDestroyed();
        }
    }
    public void Start()
    {
        currentHealth = maxHealth;

    }


}
