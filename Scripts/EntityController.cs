using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Rigidbody2D rigidbody;
    private Animator animatorController;
    private Entity entity;

    private MoveDirection direction = MoveDirection.Right;

    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
        entity = new Entity(transform, rigidbody);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            entity.MoveRight(speed);
            direction = MoveDirection.Right;
            if (!entity.isJumping)
            {
                animatorController.Play("walk_right");
            } else
            {
                animatorController.Play("jump_right");
            }
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            entity.MoveLeft(speed);
            direction = MoveDirection.Left;
            if (!entity.isJumping)
            {
                animatorController.Play("walk_left");
                
            } else
            {
                animatorController.Play("jump_left");
            }

        } else
        {
            if (!entity.isJumping) 
            {
                if (direction == MoveDirection.Right)
                {
                    animatorController.Play("idle_right");
                } else
                {
                    animatorController.Play("idle_left");
                }
                
            }
                
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            entity.Jump(jumpForce);
            if (direction == MoveDirection.Right)
            {
                animatorController.Play("jump_right");
            } else
            {
                animatorController.Play("jump_left");
            }
            
        }


        // Player's breaking 
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) && !entity.isJumping)
        {
            if (direction == MoveDirection.Right)
            {
                rigidbody.velocity = new Vector2(1, rigidbody.velocity.y);
            } else
            {
                rigidbody.velocity = new Vector2(-1, rigidbody.velocity.y);
            }
            
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rigidPlace")
        {
            entity.isJumping = false;
        }
    }

    enum MoveDirection
    {
        Left,
        Right
    }
}
