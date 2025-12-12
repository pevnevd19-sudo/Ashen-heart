using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    private float maxHealth=100f;
    [SerializeField] private float currentHealth;
    public UnityEvent onDeath;
    [SerializeField] private Animator anim;
    [SerializeField] private Image healthbar;
    [SerializeField]GameObject objects;

    public void DamageHero(float damage)
    {
        currentHealth -= damage;
        healthbar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            anim.SetBool("IsDeath", true);
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
