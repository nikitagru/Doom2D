using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rigidbody;
    private BoxCollider2D playerCollider;

    public bool isJumping = false;

    private float walkTime = 0.0f;
    private float walkCooldown = 0.2f;

    public Player(Transform Player, Rigidbody2D rg, BoxCollider2D collider2D)
    {
        if (Player != null)
        {
            player = Player;
            rigidbody = rg;
            playerCollider = collider2D;
        }
    }

    public void MoveRight(float speed)
    {
        rigidbody.AddForce(Vector2.right * speed);
        walkTime = walkCooldown;
    }

    public void MoveLeft(float speed)
    {
        rigidbody.AddForce(Vector2.left * speed);
    }

    
    public void Jump(float jumpForce)
    {
        if (!isJumping)
        {
            rigidbody.AddForce(Vector2.up * jumpForce);
            isJumping = true;
        }
    }

    

    void Update()
    {
        
    }
}
