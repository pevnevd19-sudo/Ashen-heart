using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float lastShotTime;
    [SerializeField] LayerMask layerChar;
    public Transform findChar()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, layerChar);
        if (hits.Length <= 0)
        {

            return null ;
        }
        return hits[0].transform;
    }

    private void Update()
    {

        if (Time.time < lastShotTime + cooldown)
        {
            return;
        }
        lastShotTime = Time.time;
        Transform findChar1 = findChar();
        if (findChar1 == null)
        {
            return;
        }
        if (findChar1.TryGetComponent(out Health hp) && findChar1.TryGetComponent(out Move move))
        {
            hp.IsDamaged(damage);
        }

    }
}
