using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalScript : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject CanvasWinLvl, CanvasScreenUI, player;
    public Text textWinLvlBlue, textWinLvlRed, textWinLvlYellow;

    private int cBlue, cRed, cYellow;

    private AudioSource audioSource;
    public AudioClip dootSound;

    // Start is called before the first frame update
    void Start()
    {
        cBlue = PlayerPrefs.GetInt("potCountBlue");
        cRed = PlayerPrefs.GetInt("potCountRed");
        cYellow = PlayerPrefs.GetInt("potCountYellow");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bones")
        {
            audioSource.PlayOneShot(dootSound);
            WinLevel();
            GameManager.WinLevel();
            Destroy(player);
        }
    }

    private void WinLevel()
    {
        CanvasWinLvl.SetActive(true);
        CanvasScreenUI.SetActive(false);

        AddPot();
        WritePot();
    }    

    public void AddPot()
    {
        PlayerPrefs.SetInt("potCountBlue", cBlue + PotionBlue.countBlue);
        PlayerPrefs.SetInt("potCountRed", cRed + PotionRed.countRed);
        PlayerPrefs.SetInt("potCountYellow", cYellow + PotionYellow.countYellow);
    }

    private void WritePot()
    {
        textWinLvlBlue.text = PotionBlue.countBlue.ToString();
        textWinLvlRed.text = PotionRed.countRed.ToString();
        textWinLvlYellow.text = PotionYellow.countYellow.ToString();
    }
}
