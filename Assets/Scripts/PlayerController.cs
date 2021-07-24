using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnimation;

    [SerializeField]
    private float jumpForce = 10;

    [SerializeField]
    private float gravityModifier;

    private bool isOnGround = true;
    public bool gameOver;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;

            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
        }
    }
}