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

    private void Awake()
    {
        player = GetComponent<PlayerScript>();
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
        tempVelocity = player.maxVelocity;
    }
    public void ParceiroVelocidadeOn()
    {        
        sprite.color = Color.green;        
        player.maxVelocity += BuffVelocidade;
    }
    public void ResetPartners()
    {
        player.maxVelocity = tempVelocity;
        sprite.color = color;
    }
}
