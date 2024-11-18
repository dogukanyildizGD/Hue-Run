using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionRed : MonoBehaviour
{
    public GameObject potionEarnEffect;

    public Text redText;

    public static int countRed;

    public int countLastRed;

    private void Awake()
    {
        countRed = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        int potCountRed = PlayerPrefs.GetInt("potCountRed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bones")
        {
            if (countLastRed > 0)
            {
                countRed += countLastRed;
            }
            else
            {
                countRed++;
            }
            redText.text = countRed.ToString();
            DiePotion();
        }
    }

    private void DiePotion()
    {
        GameObject effect = (GameObject) Instantiate(potionEarnEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
