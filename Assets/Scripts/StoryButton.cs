using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryButton : MonoBehaviour
{
    public GameObject ImgProf;
    public GameObject StoryBg;
    public GameObject ButtonContinue;

    //StartScreen içerisindeki CreditsButton'ı
    public GameObject CreditsButton;

    // Start is called before the first frame update
    void Start()
    {
        ImgProf.SetActive(false);
        StoryBg.SetActive(false);
        ButtonContinue.SetActive(false);

        if (PlayerPrefs.GetInt("levelReached") >= 18)
        {
            CreditsButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void storyTrigger()
    {        
        StartCoroutine(SetTrue());
    }

    IEnumerator SetTrue()
    {
        StoryBg.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        ImgProf.SetActive(true);
        ButtonContinue.SetActive(true);
    }
}
