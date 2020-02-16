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
        Animator animator = transform.gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Player2Mount") as RuntimeAnimatorController;
        player.maxVelocity += BuffVelocidade;
        yield return new WaitForSeconds(0.1f);
        player.comParceiro = true;
    }
    //Troca a cor e muda o nome para evitar morte por espinhos do cenário
    public IEnumerator ParceiroAntiespinhoOn()
    {
        Animator animator = transform.gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("PlayerMount") as RuntimeAnimatorController;
        gameObject.name = "Antiespinho";
        yield return new WaitForSeconds(0.1f);
        player.comParceiro = true;
    }
    //Reset das variaveis do player ao sair
    public void ResetPartners(int index, Vector2 spawn)
    {
        player.maxVelocity = tempVelocity;
        sprite.color = color;
        if (gameObject.tag == "Player")
        {
            Animator animator = transform.gameObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = Resources.Load("Player") as RuntimeAnimatorController;
        }
        if (gameObject.tag == "Player2")
        {
            Animator animator = transform.gameObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = Resources.Load("Player2") as RuntimeAnimatorController;
        }
        Instantiate(parceirosMontados[index], spawn, Quaternion.identity);
    }
}
