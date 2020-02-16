using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovelScript : MonoBehaviour
{
    [Header("Plataforma Movel")]
    [Space]
    Rigidbody2D rb;
    public float movel_distancia;
    public float movel_velocidade = 1;
    Vector2 destinoMovel, comeco;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        comeco = transform.position;
        destinoMovel = new Vector2(transform.position.x + movel_distancia, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= comeco.x)
        {
            rb.velocity = new Vector2(movel_velocidade, 0);
        }
        else if (transform.position.x >= destinoMovel.x)
        {
            rb.velocity = new Vector2(-movel_velocidade, 0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + movel_distancia, transform.position.y, 0));
    }
}
