using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionEarnEffectSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClipLiquid;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(sound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator sound()
    {
        audioSource.PlayOneShot(audioClipLiquid);
        yield return 0;
    }
}
