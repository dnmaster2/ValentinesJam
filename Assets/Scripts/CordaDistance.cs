using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordaDistance : MonoBehaviour
{
    #region variaveis
    public Vector2 destino;
    public float Velocidade = 1;
    public float distancia = 2;
    public GameObject PrefabNode;
    public GameObject player;
    public GameObject ultimoNode;
    bool acabou = false;
    public List<GameObject> Nodes = new List<GameObject>();
    LineRenderer lr;
    public GameObject player2;
    bool grudada = false;
    public float minDistanciaCorda = .25f, maxDistanciaCorda = 5f;
    #endregion
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        ultimoNode = transform.gameObject;
        Nodes.Add(transform.gameObject);
    }

    void Update()
    {
        if (grudada)
        {
            transform.position = player2.transform.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, destino, Velocidade);
            if ((Vector2)transform.position != destino)
            {
                if (Vector2.Distance(player.transform.position, ultimoNode.transform.position) >= distancia)
                {
                    CriarNodo();
                }
            }
            else if (!acabou)
            {
                acabou = true;
                while (Vector2.Distance(player.transform.position, ultimoNode.transform.position) >= distancia)
                {
                    CriarNodo();
                }
                ultimoNode.GetComponent<DistanceJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && (Nodes[0].GetComponent<DistanceJoint2D>().distance > minDistanciaCorda && Nodes[0].GetComponent<DistanceJoint2D>().distance < maxDistanciaCorda))
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].GetComponent<DistanceJoint2D>().distance -= Input.GetAxis("Mouse ScrollWheel") * 10 * Time.deltaTime;
            }
        }
        
        RenderizarLinha();
    }
    void CriarNodo()
    {
        Vector2 posCriar = player.transform.position - ultimoNode.transform.position;
        posCriar.Normalize();
        posCriar *= distancia;
        posCriar += (Vector2)ultimoNode.transform.position;
        GameObject go = Instantiate(PrefabNode, posCriar, Quaternion.identity);
        go.transform.SetParent(transform);
        ultimoNode.GetComponent<DistanceJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
        ultimoNode.GetComponent<DistanceJoint2D>().distance = distancia;
        ultimoNode = go;
        Nodes.Add(ultimoNode);
    }
    void RenderizarLinha()
    {
        lr.positionCount = (Nodes.Count + 1);
        int i;
        for (i = 0; i < Nodes.Count; i++)
        {
            lr.SetPosition(i, Nodes[i].transform.position);
        }
        lr.SetPosition(i, player.transform.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            grudada = true;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
