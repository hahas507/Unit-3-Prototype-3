using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnimation;
    private AudioSource playerAudio;

    [SerializeField]
    private ParticleSystem explosionParticle;

    [SerializeField]
    private ParticleSystem dirtParticle;

    [SerializeField]
    private AudioClip jumpSound;

    [SerializeField]
    private AudioClip crashSound;

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
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");

            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;

            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();

            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}