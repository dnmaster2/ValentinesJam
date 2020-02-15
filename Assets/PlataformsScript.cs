using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsScript : MonoBehaviour
{
    [Header("Plataforma Movel")]
    [Space]
    public bool movel;
    public float movel_distancia;
    public float movel_velocidade = 1;
    Vector2 destinoMovel, comeco;
    [Header("Espinhos")]
    [Space]
    public bool espinhos;
    [Header("Parede esmagadora")]
    [Space]
    public bool esmaga;
    public float esmaga_velocidade;
    public float esmaga_distancia;
    Vector2 destinoEsmaga;
    [Header("Plataforma de Peso")]
    [Space]
    public bool peso;
    public float peso_distancia;
    public float peso_velocidade;
    Vector2 destinoPeso;
    bool pisado;
    

    private void Start()
    {
        comeco = transform.position;
        destinoMovel = new Vector2(transform.position.x + movel_distancia, transform.position.y);
        destinoEsmaga = new Vector2(transform.position.x, transform.position.y + esmaga_distancia);
        destinoPeso = new Vector2(transform.position.x, transform.position.y + peso_distancia);
    }
    private void OnDrawGizmosSelected()
    {
        if (movel)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + movel_distancia, transform.position.y, 0));       
        }
        if (esmaga)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + esmaga_distancia, 0));
        }
        if (peso)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + peso_distancia, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (espinhos || esmaga)
        {
            if (!collision.gameObject.CompareTag("Chão"))
            {
                Destroy(collision.gameObject);
            }
        }

        if (peso)
        {
            pisado = true;
        }

        if (collision.gameObject.CompareTag("Chão"))
        {
            esmaga_velocidade *= -1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (peso)
        {
            pisado = false;
        }
    }

    private void Update()
    {
        if (movel && transform.position.x <= comeco.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movel_velocidade, 0);
        }
        else if (movel && transform.position.x >= destinoMovel.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movel_velocidade, 0);
        }

        if (esmaga && transform.position.y >= comeco.y)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, esmaga_velocidade);
        }
        else if (esmaga && transform.position.y <= destinoEsmaga.y)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -esmaga_velocidade);
        }

        if (pisado)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, peso_velocidade);
        }
        else if(comeco.y >= transform.position.y)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -peso_velocidade);
        }
    }
}
