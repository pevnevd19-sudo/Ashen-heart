using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed;
    private Vector2 movement;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator anim;
    public void setdirection (Vector2 vector)
    {
        movement = vector;
    }

    private void FixedUpdate()
    {
        rb.MovePosition (rb.position + movement * speed * Time.fixedDeltaTime);
    }
    
}
