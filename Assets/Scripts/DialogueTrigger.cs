using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        //TriggerDialog();
    }

    public void TriggerDialog()
    {
        if (SceneManager.GetActiveScene().name == "ImageScreen")
        {
            FindObjectOfType<DialogManager2>().StartDialogue(dialogue);
        }
        else
        {
            FindObjectOfType<DialogManager>().StartDialogue(dialogue);
        }        
    }
}
