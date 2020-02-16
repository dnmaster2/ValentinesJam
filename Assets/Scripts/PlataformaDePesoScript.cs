using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDePesoScript : MonoBehaviour
{
    public float peso_distancia;
    public float peso_velocidade;
    Vector2 destinoPeso;
    public bool pisado;
    Rigidbody2D rb;
    Vector2 comeco;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        comeco = transform.position;
        destinoPeso = new Vector2(transform.position.x, transform.position.y + peso_distancia);
    }

    // Update is called once per frame
    void Update()
    {
        if (pisado && transform.position.y >= destinoPeso.y)
        {
            rb.velocity = new Vector2(0, peso_velocidade);
        }
        else if (pisado && transform.position.y <= destinoPeso.y)
        {
            rb.velocity = Vector2.zero;
        }
        else if (!pisado && transform.position.y <= comeco.y - .25f)
        {
            rb.velocity = new Vector2(0, -peso_velocidade);
        }
        else if (!pisado && transform.position.y >= comeco.y)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pisado = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        pisado = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + peso_distancia, 0));
    }
}
