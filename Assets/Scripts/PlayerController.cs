using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;

    public Animator playerAnimator;

    public GameObject player;

    public float speed;
    public float jumpForce;

    private bool isOnGround;

    void Update()
    {
        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                if (player.GetComponent<SpriteRenderer>().flipX == true)
                {
                    player.GetComponent<SpriteRenderer>().flipX = false;
                }
                playerAnimator.SetBool("isJumping", true);
                playerAnimator.SetBool("isRunning", false);
            }
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
            playerAnimator.SetBool("isRunning", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            if (player.GetComponent<SpriteRenderer>().flipX == false)
            {
                player.GetComponent<SpriteRenderer>().flipX = true;
            }
            playerAnimator.SetBool("isRunning", true);
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

        if(collision.gameObject.name == "Floor")
        {
            isOnGround = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            playerAnimator.SetBool("isJumping", false);
        }
    }
}
