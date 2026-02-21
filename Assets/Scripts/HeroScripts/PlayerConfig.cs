using UnityEngine;

[CreateAssetMenu(menuName = "PlayerConfig/Player", fileName = "ConfigMovement")]
public class PlayerConfig : ScriptableObject
{
   

        public float _speed = 5f;
        public float _maxSpeed = 10f;
        public float _jumpForce = 2f;
        public float smoothing = 5f;
}
