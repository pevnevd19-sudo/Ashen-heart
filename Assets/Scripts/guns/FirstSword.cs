using UnityEditor.Tilemaps;
using UnityEngine;

public class FirstSword : AbstractGun
{
    private int _damage;
    private int _cooldown;

    public int Damage {get => _damage;}
    public int Cooldown {get => _cooldown;}
    public override void Gun(int damage, int cooldown)
    {
        damage = 5;
        cooldown = 3;
        _damage = damage;
        _cooldown = cooldown;

    }
}
