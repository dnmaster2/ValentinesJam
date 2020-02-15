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
        if(transform.position.x > )
    }
}
