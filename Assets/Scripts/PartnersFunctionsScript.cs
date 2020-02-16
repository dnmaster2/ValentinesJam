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

    private void Awake()
    {
        player = GetComponent<PlayerScript>();
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
        tempVelocity = player.maxVelocity;
    }
    public IEnumerator ParceiroVelocidadeOn()
    {
        sprite.color = Color.green;
        player.maxVelocity += BuffVelocidade;
        yield return new WaitForSeconds(0.1f);
        player.comParceiro = true;
    }
    public IEnumerator ParceiroAntiespinhoOn()
    {
        sprite.color = Color.white;
        gameObject.name = "Antiespinho";
        yield return new WaitForSeconds(0.1f);
        player.comParceiro = true;
    }

    public void ResetPartners(int index, Vector2 spawn)
    {
        player.maxVelocity = tempVelocity;
        sprite.color = color;
        Instantiate(parceirosMontados[index], spawn, Quaternion.identity);
    }
}
