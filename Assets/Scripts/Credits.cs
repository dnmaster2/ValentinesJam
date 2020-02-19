using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    //lista de posicoes onde o menu fica
    public List<Vector2> posicoes = new List<Vector2>(2);
    //posicao atual do menu
    public int posicaoAtual;
    //velocidade usada apenas para referencia
    public Vector2 velocidade;
    //tempo que demora para o menu chegar na nova posicao
    public float tempoSmooth;
    //som do click do botao sai desse lugar
    AudioSource som;
    void Start()
    {
        //a posicao inicial do menu sempre sera 0
        posicaoAtual = 0;
        //preenche o lugar onde esta co click do botao
        som = GetComponent<AudioSource>();
    }
    void Update()
    {
        //smooth damp (calculo matematico por isso ta no update)
        transform.position = Vector2.SmoothDamp(transform.position, posicoes[posicaoAtual],ref velocidade, tempoSmooth);
    }
    public void CreditsButton()
    {
        //executa a funcao de som
        AudioClick();
        //muda a posicao atual do menu
        posicaoAtual = 1;
    }
    public void Controls()
    {
        //executa a funcao de som
        AudioClick();
        //muda a posicao atual do menu
        posicaoAtual = 2;
    }
    public void BackButton()
    {
        //executa a funcao de som
        AudioClick();
        //muda a posicao atual do menu
        posicaoAtual = 0;
    }
    public void Password()
    {
        AudioClick();
        posicaoAtual = 3;
    }
    void AudioClick()
    {
        //randomiza o pitch do click para parecer clicks diferentes, mas é sempre o mesmo
        som.pitch = Random.Range(.5f, 1.5f);
        //da play no som
        som.Play();
    }
}
