using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBlue : MonoBehaviour
{
    public Camera Camera;
    public SpriteRenderer spriteRenderer;

    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bones" && Camera.backgroundColor != Colors.ColorBlue())
        {
            Debug.Log("GAME OVER!");
            //Destroy(gameObject);
            GameManager.GameOver();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bones" && Camera.backgroundColor != Colors.ColorBlue())
        {
            Debug.Log("GAME OVER!");
            //Destroy(gameObject);
            GameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.backgroundColor == Colors.ColorBlue())
        {
            //Destroy(gameObject);
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }
}
