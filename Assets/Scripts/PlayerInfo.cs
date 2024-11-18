using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInfo : MonoBehaviour
{
    // move
    public Rigidbody2D playerRb;
    public float xSpeed = 10f;
    private Vector2 xForce;

    // Jump
    public float jumpForce;

    // Ground Check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Animator
    public Animator animator;

    // Start Timer
    public Text countDownStart;
    private float countDown = 4f;
    private bool moveBool = false;

    public Camera Camera;

    AudioSource audioSource;
    public AudioClip footStepSound;
    public float footstepDelay;
    private float nextFootstep = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (countDown <= 0f)
        {
            countDownStart.enabled = false;
            moveBool = true;
        }
        countDown -= Time.deltaTime;
        countDownStart.text = Math.Floor(countDown).ToString();

        footStepFunk();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        xForce = new Vector2(xSpeed * Time.deltaTime, 0);        

        //playerRb.AddForce(xForce);
        if (moveBool)
        {
            playerRb.velocity = xForce.normalized * xSpeed;
            animator.enabled = true;

            if (CrossPlatformInputManager.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow))
            {
                jump();
            }

            if (CrossPlatformInputManager.GetButton("Slide") || Input.GetKey(KeyCode.DownArrow))
            {
                audioSource.Stop();
                animator.SetBool("isSliding", true);
            }
            else
            {
                animator.SetBool("isSliding", false);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            Camera.backgroundColor = Colors.ColorRed();
        }

        if (Input.GetKey(KeyCode.S))
        {
            Camera.backgroundColor = Colors.ColorBlue();
        }

        if (Input.GetKey(KeyCode.D))
        {
            Camera.backgroundColor = Colors.ColorYellow();
        }

    }

    private void footStepFunk()
    {
        nextFootstep -= Time.deltaTime;
        if (nextFootstep <= 0 && moveBool)
        {
            audioSource.PlayOneShot(footStepSound);
            nextFootstep += footstepDelay;
        }
    }

    public void jump()
    {
        audioSource.Stop();
        if (isGrounded == true)
        {
            playerRb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Impulsa eğrisine göre.   
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
