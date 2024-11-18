using UnityEngine;
using UnityEngine.UI;

public class BtnImageChange : MonoBehaviour
{
    //Sb-Image ve Renkli-Image
    public Sprite imageSB;
    public Sprite imageNormal;

    public Button button;
    public GameObject canvasBiggerImage;
    public Image bigImage;
    public GameObject imageTransBG;
    public GameObject buttonUse;

    private Sprite temp;

    //Harcanacak Pot
    [Header("Harcanacak Pot ve Text")]
    public int spendPot;
    public Text textSpendRed, textSpendBlue, textSpendYellow;

    //Vt kayıt edilecek resim
    [Header("Save Image")]
    public string imageNameNormal;
    public string imageNameSB;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("potCountRed", 9999);
        //PlayerPrefs.SetInt("potCountBlue", 9999);
        //PlayerPrefs.SetInt("potCountYellow", 9999);

        canvasBiggerImage.SetActive(false);

        PlayerPrefs.GetString(imageNameNormal, imageNameNormal);        
    }

    // Update is called once per frame
    void Update()
    {
        Buyed();

        PlayerPrefs.GetString(imageNameNormal);

        textSpendRed.text = spendPot.ToString();
        textSpendBlue.text = spendPot.ToString();
        textSpendYellow.text = spendPot.ToString();
        
    }

    public void UseButton()
    {
        int spendRed = PlayerPrefs.GetInt("potCountRed") - spendPot;
        int spendBlue = PlayerPrefs.GetInt("potCountBlue") - spendPot;
        int spendYellow = PlayerPrefs.GetInt("potCountYellow") - spendPot;

        if (spendRed >= 0 && spendBlue >= 0 && spendYellow >= 0)
        {
            PlayerPrefs.SetInt("potCountRed", spendRed);
            PlayerPrefs.SetInt("potCountBlue", spendBlue);
            PlayerPrefs.SetInt("potCountYellow", spendYellow);

            button.image.sprite = imageNormal;
            temp = button.image.sprite;
            bigImage.sprite = temp;

            PlayerPrefs.SetString(imageNameNormal, imageNameSB);

            Buyed();
        }
    }

    private void Buyed()
    {
        if (PlayerPrefs.GetString(imageNameNormal).Equals(imageNameSB))
        {
            buttonUse.SetActive(false);
            button.image.sprite = imageNormal;
        }
        else
        {
            buttonUse.SetActive(true);
        }
    }

    public void BackButton()
    {
        canvasBiggerImage.SetActive(false);
        imageTransBG.SetActive(false);
    }

    public void ButtonDown()
    {        
        bigImage.sprite = button.image.sprite;
        canvasBiggerImage.SetActive(true);
        imageTransBG.SetActive(true);

    }
}
