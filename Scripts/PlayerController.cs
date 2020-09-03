using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Rigidbody2D rigidbody;
    public Transform player;
    private Animator animatorController;
    public BoxCollider2D playerCollider;
    private Player playerEntity;

    private MoveDirection direction = MoveDirection.Right;

    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        playerEntity = new Player(player, rigidbody, playerCollider);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerEntity.MoveRight(speed);
            direction = MoveDirection.Right;
            if (!playerEntity.isJumping)
            {
                animatorController.Play("walk_right");
            } else
            {
                animatorController.Play("jump_right");
            }
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            playerEntity.MoveLeft(speed);
            direction = MoveDirection.Left;
            if (!playerEntity.isJumping)
            {
                animatorController.Play("walk_left");
                
            } else
            {
                animatorController.Play("jump_left");
            }

        } else
        {
            if (!playerEntity.isJumping) 
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
            playerEntity.Jump(jumpForce);
            if (direction == MoveDirection.Right)
            {
                animatorController.Play("jump_right");
            } else
            {
                animatorController.Play("jump_left");
            }
            
        }

        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) && !playerEntity.isJumping)
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
            playerEntity.isJumping = false;
        }
    }

    enum MoveDirection
    {
        Left,
        Right
    }
}
