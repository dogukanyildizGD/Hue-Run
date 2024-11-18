using UnityEngine;
using UnityEngine.UI;

public class PotionBlue : MonoBehaviour
{
    public GameObject potionEarnEffect;

    public Text blueText;

    public static int countBlue;

    public int countLastBlue;    

    private void Awake()
    {
        countBlue = 0;
    }

    // Start is called before the first frame update
    void Start()
    {        
        int potCountBlue = PlayerPrefs.GetInt("potCountBlue", 0);
    }

    // Update is called once per frame
    void Update()
    {      
               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player") || collision.tag == "Bones")
        {            
            if (countLastBlue > 0)
            {
                countBlue += countLastBlue;
            }
            else
            {
                countBlue++;
            }            
            blueText.text = countBlue.ToString();                       
            DiePotion();            
        }
    }

    private void DiePotion()
    {        
        GameObject effect = (GameObject) Instantiate(potionEarnEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
