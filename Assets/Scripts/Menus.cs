using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    //som do click do botao sai desse lugar
    AudioSource som;
    private void Start()
    {
        //preenche o lugar onde esta co click do botao
        som = GetComponent<AudioSource>();
    }
    public void StartButton()
    {
        //executa a funcao de som
        AudioClick();
        //fecha o jogo
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
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
