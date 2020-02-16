using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    AudioSource som;
    private void Start()
    {
        som = GetComponent<AudioSource>();
    }
    public void StartButton()
    {
        AudioClick();
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        AudioClick();
        Application.Quit();
    }
    void AudioClick()
    {
        som.pitch = Random.Range(.5f, 1.5f);
        som.Play();
    }
}
