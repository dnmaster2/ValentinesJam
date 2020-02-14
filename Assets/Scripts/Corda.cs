using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corda : MonoBehaviour
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
    #endregion
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        ultimoNode = transform.gameObject;
        Nodes.Add(transform.gameObject);
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destino, Velocidade);
        if ((Vector2)transform.position != destino)
        {
            if (Vector2.Distance(player.transform.position,ultimoNode.transform.position)>=distancia)
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
            ultimoNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
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
        ultimoNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
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
}
