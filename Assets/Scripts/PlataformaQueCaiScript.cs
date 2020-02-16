using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaQueCaiScript : MonoBehaviour
{
    public float tempo_cair;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(TimerQueda());
    }

    IEnumerator TimerQueda()
    {
        print("rodei de novo");
        yield return new WaitForSeconds(tempo_cair);
        print("rodei mais uma vez");
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 3f;
    }
}
