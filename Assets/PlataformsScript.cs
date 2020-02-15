using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsScript : MonoBehaviour
{
    public bool movel;
    public float movel_distancia;

    // Update is called once per frame
    void Update()
    {
        if (movel)
        {
            if (transform.position.x < movel_distancia + transform.position.x)
            {
                Vector2 direcao = new Vector2(transform.position.x + movel_distancia, transform.position.y);
                transform.Translate(direcao);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (movel)
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + movel_distancia, transform.position.y, 0));
            Gizmos.color = Color.green;
        }
    }
}
