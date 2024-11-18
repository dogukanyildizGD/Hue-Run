using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panelButtons;
    public GameObject panelEndGame;
    public GameObject panelPots;
    public SceneFader sceneFader;

    public string StartScene = "StartScene";

    public string nextLevel = "Level002";
    public int levelToUnlock = 2;

    public Text levelText,textLevelComp;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = SceneManager.GetActiveScene().name.ToString();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdMobGecis()
    {
        sceneFader.FateTo("AdMobDeneme");        
    }

    public void StartGame()
    {
        sceneFader.FateTo(StartScene);        
        Time.timeScale = 1f;        
    }

    public void WinLevel()
    {
        if (PlayerPrefs.GetInt("levelReached") < levelToUnlock)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        textLevelComp.text = SceneManager.GetActiveScene().name.ToString() + " Completed";
    }

    public void ImageScreen()
    {
        sceneFader.FateTo("ImageScreen");
    }

    public void NextLevel()
    {        
        sceneFader.FateTo(nextLevel);
    }

    public void GameOver()
    {
        panelButtons.SetActive(false);
        panelEndGame.SetActive(true);
        panelPots.SetActive(false);

        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        sceneFader.FateTo(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        sceneFader.FateTo("StartScreen");
        Time.timeScale = 1f;
    }

    public void EndScreen()
    {
        sceneFader.FateTo("EndScreen");
        Time.timeScale = 1f;
    }
}
