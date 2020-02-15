using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformsScript : MonoBehaviour
{
    public bool movel;
    public float movel_distancia;
    Vector2 direcao, origem;

    private void Start()
    {
        origem = transform.position;
        direcao = new Vector2(transform.position.x + movel_distancia, transform.position.y);
    }

    void Update()
    {       
        if (movel)
        {
            if (transform.position.x > direcao.x)
            {
                print("voltano");
                transform.Translate(Vector2.left * Time.deltaTime);
            }

            if (transform.position.x < direcao.x)
            {
                print("ino");
                transform.Translate(Vector2.right * Time.deltaTime);
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
