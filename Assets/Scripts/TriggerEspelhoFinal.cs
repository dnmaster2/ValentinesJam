using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEspelhoFinal : MonoBehaviour
{

    public GameObject sprite1, sprite2, gameOver;
    public int vezes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite1.SetActive(true);
            vezes++;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            sprite2.SetActive(true);
            vezes++;
        }
    }

    private void Update()
    {
        if(vezes == 2)
        {
            gameOver.SetActive(true);
        }
    }
}
