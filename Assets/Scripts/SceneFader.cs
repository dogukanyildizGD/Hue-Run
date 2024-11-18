using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
        audioSource = GetComponent<AudioSource>();
    }

    public void ToFate()
    {
        StartCoroutine(FadeIn());
    }

    public void FateTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;
        
        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t > 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        if (scene != null)
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            Debug.Log("scene is empty");
        }

        
    }
}
