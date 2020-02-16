using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaEsmagadoraScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 comeco;
    public float esmaga_velocidade;
    public float esmaga_distancia;
    Vector2 destinoEsmaga;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        comeco = transform.position;
        destinoEsmaga = new Vector2(transform.position.x, transform.position.y + esmaga_distancia);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= comeco.y)
        {
            rb.velocity = new Vector2(0, esmaga_velocidade);
        }
        else if (transform.position.y <= destinoEsmaga.y)
        {
            rb.velocity = new Vector2(0, -esmaga_velocidade);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Chão") && collision.gameObject.name != "Antiespinho")
        {
            esmaga_velocidade *= -1;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + esmaga_distancia, 0));
    }
}
