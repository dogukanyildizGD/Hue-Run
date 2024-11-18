using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;

    public Button[] LevelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                LevelButtons[i].interactable = false;
            }            
        }
    }

    public void Select(string levelName)
    {
        sceneFader.FateTo(levelName);       
    }
}
