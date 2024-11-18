using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonsControl : MonoBehaviour
{
    public GameObject buttonJump;
    public GameObject buttonSlide;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("levelReached") >= 3)
        {
            buttonJump.SetActive(true);
            buttonSlide.SetActive(true);
        }
        else
        {
            buttonJump.SetActive(false);
            buttonSlide.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
