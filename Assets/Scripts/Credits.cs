using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public List<Vector2> posicoes = new List<Vector2>(2);
    public int posicaoAtual;
    public Vector2 velocidade;
    public float tempoSmooth; AudioSource som;
    void Start()
    {
        posicaoAtual = 0;
        som = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, posicoes[posicaoAtual],ref velocidade, tempoSmooth);
    }
    public void CreditsButton()
    {
        AudioClick();
        posicaoAtual = 1;
    }
    public void BackButton()
    {
        AudioClick();
        posicaoAtual = 0;
    }
    void AudioClick()
    {
        som.pitch = Random.Range(.5f, 1.5f);
        som.Play();
    }
}
