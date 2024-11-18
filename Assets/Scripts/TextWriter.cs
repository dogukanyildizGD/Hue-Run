using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private float timePerCharacter;
    private bool invisibleCrahacters;

    private float timer;
    private int characterIndex;
    

    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCrahacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCrahacters = invisibleCrahacters;
        characterIndex = 0;
    }

    private void Update()
    {
        if (uiText != null)
        {
            timer = -Time.deltaTime;
            while (timer <= 0f)
            {
                // Display next character
                timer += timePerCharacter;
                characterIndex++;
                string t = "<color=#2D5D73>" + textToWrite.Substring(0, characterIndex) + "</color>";

                if (invisibleCrahacters)
                {
                    t += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = t;

                if (characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }            
        }
    }
}
