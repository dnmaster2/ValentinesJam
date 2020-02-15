using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsScript : MonoBehaviour
{
    public bool movel;
    public float movel_distancia;
    public bool espinhos;
    public bool esmaga;
    public bool peso;
    float destino, comeco;

    private void Start()
    {
        comeco = transform.position.x;
        destino = transform.position.x + movel_distancia;
    }
    private void OnDrawGizmosSelected()
    {
        if (movel)
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + movel_distancia, transform.position.y, 0));
            Gizmos.color = Color.green;
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

        }
    }

    private void Update()
    {
        if (movel && transform.position.x <= comeco)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        }
        else if (movel && transform.position.x >= destino)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
        }
    }
}
