using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbstractGun : MonoBehaviour
{
    private int _damage;
    private int _cooldown;

    public int Damage {get => _damage;}
    public int Cooldown {get => _cooldown;}
       public virtual void Gun(int damage, int cooldown)
    {
        _cooldown = cooldown;
        _damage = damage;
    }
}
