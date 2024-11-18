using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Text textName;
    public Text textDialogue;
    public Text textContinueButton;

    public GameObject ImgProf;
    public GameObject StoryBg;
    public GameObject ButtonContinue;
    public Button BtnContinue;

    public GameObject CreditsScreen;
    public GameObject StoryButton;
    public GameObject CreditsTexts;
    public Animator animatorCredits;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        textDialogue.text = "";
        BtnContinue.interactable = false;
        CreditsScreen.SetActive(false);
        CreditsTexts.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        StartCoroutine(StartDialogueCntrl(dialogue));
    }

    IEnumerator StartDialogueCntrl(Dialogue dialogue)
    {
        yield return new WaitForSecondsRealtime(4f);

        textName.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        BtnContinue.interactable = true;
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (sentences.Count == 1)
        {
            textContinueButton.text = "Close";
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));        
    }

    IEnumerator TypeSentence (string sentence)
    {
        textDialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textDialogue.text += "<color=#2D5D73>" + letter + "</color>";
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    void EndDialogue()
    {
        textContinueButton.text = "Continue";

        ImgProf.SetActive(false);
        StoryBg.SetActive(false);
        ButtonContinue.SetActive(false);

        sentences.Clear();
        sentences = new Queue<string>();

        if (SceneManager.GetActiveScene().name == "EndScreen")
        {
            Credits();
        }
    }

    private void Credits()
    {
        CreditsScreen.SetActive(true);
        CreditsTexts.SetActive(true);
        StoryButton.SetActive(false);
    }
}
