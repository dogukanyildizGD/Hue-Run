using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Assistant : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    private Text messageText;

    private void Awake()
    {
        messageText = transform.Find("CanvasProfText").Find("messageText").GetComponent<Text>();
        //Application.targetFrameRate = 12;
    }

    private void Start()
    {
        textWriter.AddWriter(messageText, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 1f, true);
    }
}
