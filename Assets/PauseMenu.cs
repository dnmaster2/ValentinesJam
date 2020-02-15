using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject BotaoPause;
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
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitDesktop()
    {
        Application.Quit();
    }
}
