using System;
using UnityEngine;
using UnityEngine.UI;

public class dreamE : MonoBehaviour
{
    // Move
    public Rigidbody2D dreamERb;
    public float xSpeed = 10f;
    private Vector2 xForce;

    // Start Timer
    public Text countDownStart;
    private float countDown = 4f;
    private bool moveBool = false;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemies")
        {
            xSpeed -= 0.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemies")
        {
            xSpeed += 0.5f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0f)
        {
            countDownStart.enabled = false;
            moveBool = true;
        }
        countDown -= Time.deltaTime;
        countDownStart.text = Math.Floor(countDown).ToString();
    }

    private void FixedUpdate()
    {
        if (moveBool)
        {
            xForce = new Vector2(xSpeed * Time.deltaTime, 0);
            dreamERb.velocity = xForce.normalized * xSpeed;
            animator.enabled = true;

            // İyi olan bu fakat playerda diğer speed
            // kullanıldığı için burada da onu kullandık.
            //transform.Translate(Vector2.right * Time.deltaTime * xSpeed);
        }
    }
}
