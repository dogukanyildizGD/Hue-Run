using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager2 : MonoBehaviour
{
    private string[] sentences;

    public Text textDialogue;
    public Text textName;

    public DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        textDialogue.text = "";
        dialogueTrigger.TriggerDialog();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        StartCoroutine(StartDialogueCntrl(dialogue));        
    }

    private void shuffleArray(string[] sentences)
    {
        int n = sentences.Length;        

        for (int i = 0; i < n; i++)
        {
            int randomInt = UnityEngine.Random.Range(1, n - i);
            swap(sentences, i, randomInt);
        }
    }

    private void swap(string[] sentences, int a, int b)
    {
        string temp = sentences[a];
        sentences[a] = sentences[b];
        sentences[b] = temp;
    }

    IEnumerator StartDialogueCntrl(Dialogue dialogue)
    {
        textName.text = dialogue.name;

        shuffleArray(dialogue.sentences);

        string sentence = dialogue.sentences[0];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        yield return 0;
    }

    IEnumerator TypeSentence(string sentence)
    {
        textDialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textDialogue.text += "<color=#2D5D73>" + letter + "</color>";
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
