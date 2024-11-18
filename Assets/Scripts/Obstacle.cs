using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bones")
        {
            Debug.Log("GAME OVER!");
            //Destroy(gameObject);
            GameManager.GameOver();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bones")
        {
            Debug.Log("GAME OVER!");
            //Destroy(gameObject);
            GameManager.GameOver();
        }
    }

}
