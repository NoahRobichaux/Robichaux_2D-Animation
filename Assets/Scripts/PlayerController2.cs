using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Animator playerAnimator;
    SpriteRenderer playerSR;
    bool isOnGround;
    public float speed;
    public float jumpForce;
    bool haveControl;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (haveControl)
        {
            playerRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") + speed, playerRigidbody.velocity.y);
            if (playerRigidbody.velocity.x > 0 || playerRigidbody.velocity.x < 0)
            {
                if (isOnGround)
                {
                    playerAnimator.SetBool("isRunning", true);
                    if (playerRigidbody.velocity.x > 0)
                    {
                        playerSR.flipX = false;
                    }
                    if (playerRigidbody.velocity.x < 0)
                    {
                        playerSR.flipX = true;
                    }
                }
            }
            else
            {
                playerAnimator.SetBool("isRunning", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                playerAnimator.SetBool("isJumping", true);
                playerAnimator.SetBool("isRunning", false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            playerAnimator.SetBool("isJumping", false);
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            playerAnimator.SetBool("isSpawning", true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnGround = false;
        }
    }
    public void GiveControl()
    {
        haveControl = true;
    }
}
