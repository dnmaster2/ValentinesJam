using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject BotaoPause;
    AudioSource som;
    private void Start()
    {
        som = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseAndResume();
        }
    }
    public void PauseAndResume()
    {
        PauseMenuUI.SetActive(!PauseMenuUI.activeSelf);
        BotaoPause.SetActive(!BotaoPause.activeSelf);
        AudioClick();
    }
    public void Restart()
    {
        AudioClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        AudioClick();
        SceneManager.LoadScene(0);
    }
    public void QuitDesktop()
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
