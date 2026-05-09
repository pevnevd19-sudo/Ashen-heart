using UnityEngine;

[CreateAssetMenu(menuName = "PlayerConfig/Player", fileName = "ConfigMovement")]
public class PlayerConfig : ScriptableObject
{
    public float CurrentSpeed;

    public float RunSpeed = 6f;

    public float SprintSpeed = 10f;

    public float JumpForce = 6f;

    public float Smoothing = 5f;

    public float JumpCooldown = 1.36f;

    public float CrouchSpeed = 2f;
}
