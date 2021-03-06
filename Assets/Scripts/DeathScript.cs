﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject gameOverObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name != "Antiespinho")
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
            {
                gameOverObject.SetActive(true);
                Destroy(collision.gameObject);
            }
        }       
    }
}
