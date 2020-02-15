using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public List<Vector2> posicoes = new List<Vector2>(2);
    public int posicaoAtual;
    public Vector2 velocidade;
    public float tempoSmooth;
    void Start()
    {
        posicaoAtual = 0;
    }
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, posicoes[posicaoAtual],ref velocidade, tempoSmooth);
    }
    public void CreditsButton()
    {
        posicaoAtual = 1;
    }
    public void BackButton()
    {
        posicaoAtual = 0;
    }
}
