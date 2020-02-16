using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEspelhoFinal : MonoBehaviour
{
    public GameObject sprite1, sprite2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite1.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            sprite2.SetActive(true);
        }
    }
}
