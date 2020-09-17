using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rigidbody;
    
    public bool isFlip = false;
    public bool isJumping = false;

    public Entity(Transform Player, Rigidbody2D rg)
    {
        if (Player != null)
        {
            player = Player;
            rigidbody = rg;
        }
    }

    public void MoveRight(float speed)
    {
        rigidbody.AddForce(Vector2.right * speed);
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

    public void Flip()
    {
        player.Rotate(0f, 180f, 0f);
    }

    

    void Update()
    {
        
    }
}
