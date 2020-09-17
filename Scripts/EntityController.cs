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

    private bool isRightDir = true;

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
            if (!isRightDir)
            {
                entity.Flip();
                isRightDir = true;
            }
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
            if (isRightDir)
            {
                entity.Flip();
                isRightDir = false;
            }
            entity.MoveLeft(speed);
            direction = MoveDirection.Left;
            if (!entity.isJumping)
            {
                animatorController.Play("walk_right");
            }
            else
            {
                animatorController.Play("jump_right");
            }

        } else
        {
            if (!entity.isJumping) 
            {
                animatorController.Play("idle_right");
            }
                
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            entity.Jump(jumpForce);
            animatorController.Play("jump_right");
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
