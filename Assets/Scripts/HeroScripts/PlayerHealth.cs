using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] public float currentHealth;
    public UnityEvent onDeath;
    [SerializeField] private Image healthbar;
    [SerializeField] GameObject objects;
    [SerializeField] Animator playerAnimator;

    public void IsDamaged(float damage)
    {
        currentHealth -= damage;
        healthbar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 1f)
        {
            currentHealth = 0;
            onDeath.Invoke();
            objects.IsDestroyed();
        }
    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        healthbar.fillAmount = currentHealth / maxHealth;
    }
    public void Die()
    {
        playerAnimator.Play("Die");
        currentHealth = 0;
    }
    public void Start()
    {
        currentHealth = maxHealth;
        Mathf.Clamp(currentHealth, 0, 100);

    }


}
