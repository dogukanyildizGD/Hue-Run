using UnityEngine;
using UnityEngine.UI;

public class PotionYellow : MonoBehaviour
{
    public GameObject potionEarnEffect;

    public Text yellowText;

    public static int countYellow;

    public int countLastYellow;

    private void Awake()
    {
        countYellow = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        int potCountYellow = PlayerPrefs.GetInt("potCountYellow", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bones")
        {
            if (countLastYellow > 0)
            {
                countYellow += countLastYellow;
            }
            else
            {
                countYellow++;
            }
            yellowText.text = countYellow.ToString();
            DiePotion();
        }
    }

    private void DiePotion()
    {
        GameObject effect = (GameObject)Instantiate(potionEarnEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
