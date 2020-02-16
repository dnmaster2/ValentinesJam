using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //menu de pausa
    public GameObject PauseMenuUI;
    //botao de pausa
    public GameObject BotaoPause;
    //som do click do botao sai desse lugar
    AudioSource som;
    private void Start()
    {
        //preenche o lugar onde esta co click do botao
        som = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //executa a funcao de pause
            PauseAndResume();
        }
    }
    public void PauseAndResume()
    {
        //inverte o estado do menu de pausa
        PauseMenuUI.SetActive(!PauseMenuUI.activeSelf);
        //inverte o estado do botao de pausa
        BotaoPause.SetActive(!BotaoPause.activeSelf);
        //executa a funcao de som
        AudioClick();
    }
    public void Restart()
    {
        //executa a funcao de som
        AudioClick();
        //carrega a cena que estava
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        //executa a funcao de som
        AudioClick();
        //carrega a cena 0 (main menu)
        SceneManager.LoadScene(0);
    }
    public void QuitDesktop()
    {
        //executa a funcao de som
        AudioClick();
        //fecha o jogo
        Application.Quit();
    }
    void AudioClick()
    {
        //randomiza o pitch do click para parecer clicks diferentes, mas é sempre o mesmo
        som.pitch = Random.Range(.5f, 1.5f);
        //da play no som
        som.Play();
    }
}
