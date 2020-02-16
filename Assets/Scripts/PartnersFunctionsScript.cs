using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartnersFunctionsScript : MonoBehaviour
{
    public float BuffVelocidade;
    PlayerScript player;
    SpriteRenderer sprite;
    float tempVelocity;
    Color color;
    public List<GameObject> parceirosMontados;

    //Load
    private void Awake()
    {
        player = GetComponent<PlayerScript>();
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
        tempVelocity = player.maxVelocity;
    }
    //Troca a cor e aumenta a velocidade, e depois checa a booleana
    public IEnumerator ParceiroVelocidadeOn()
    {
        sprite.color = Color.green;
        player.maxVelocity += BuffVelocidade;
        yield return new WaitForSeconds(0.1f);
        player.comParceiro = true;
    }
    //Troca a cor e muda o nome para evitar morte por espinhos do cenário
    public IEnumerator ParceiroAntiespinhoOn()
    {
        sprite.color = Color.white;
        gameObject.name = "Antiespinho";
        yield return new WaitForSeconds(0.1f);
        player.comParceiro = true;
    }
    //Reset das variaveis do player ao sair
    public void ResetPartners(int index, Vector2 spawn)
    {
        player.maxVelocity = tempVelocity;
        sprite.color = color;
        Instantiate(parceirosMontados[index], spawn, Quaternion.identity);
    }
}
