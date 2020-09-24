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
        player.position += Vector3.right * speed * Time.deltaTime;
        //rigidbody.AddForce(Vector2.right * speed);
    }

    public void MoveLeft(float speed)
    {
        player.position += Vector3.left * speed * Time.deltaTime;
        
        //rigidbody.AddForce(Vector2.left * speed);
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

    public void WallCollision(bool isRightDir)
    {
        if (isRightDir)
        {
            player.position += Vector3.left * Time.deltaTime;
            Debug.Log("going left");
        } else
        {
            player.position += Vector3.right * Time.deltaTime;
            Debug.Log("going right");
        }
    }

    void Update()
    {
        
    }
}
