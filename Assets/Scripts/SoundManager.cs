using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public List<AudioClip> clips;
    int a;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex >= 2)
        {
            audioSource.clip = clips[1];
            audioSource.Play();
        }

        if(SceneManager.GetActiveScene().buildIndex == 11)
        {
            audioSource.clip = clips[2];
            audioSource.Play();
        }
    }
}
