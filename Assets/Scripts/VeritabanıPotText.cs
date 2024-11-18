using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeritabanıPotText : MonoBehaviour
{
    private int potsRed, potsBlue, potsYellow;
    public Text textRed, textBlue, textYellow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        potsRed = PlayerPrefs.GetInt("potCountRed");
        potsBlue = PlayerPrefs.GetInt("potCountBlue");
        potsYellow = PlayerPrefs.GetInt("potCountYellow");

        textRed.text = potsRed.ToString();
        textBlue.text = potsBlue.ToString();
        textYellow.text = potsYellow.ToString();
    }

}
