using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCordao : MonoBehaviour
{
    public List<DistanceJoint2D> joints;
    public Rigidbody2D noCordaoPlayer1, noCordaoPlayer2;
    public GameObject player1, player2;
    public LineRenderer lr;
    public float forcaPuxar;
    void Start()
    {
        joints.Add(GameObject.Find("NoCordaoPlayer1").GetComponent<DistanceJoint2D>());
        joints.Add(GameObject.Find("NoCordaoPlayer2").GetComponent<DistanceJoint2D>());
        joints.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<DistanceJoint2D>());
        joints.Add(GameObject.FindGameObjectWithTag("Player2").GetComponent<DistanceJoint2D>());
        noCordaoPlayer1 = GameObject.Find("NoCordaoPlayer1").GetComponent<Rigidbody2D>();
        noCordaoPlayer2 = GameObject.Find("NoCordaoPlayer2").GetComponent<Rigidbody2D>();
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        AtivarCordao();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AtivarCordao();
        }
        if (Input.GetKey(KeyCode.K))
        {
            joints[0].distance -= forcaPuxar * Time.deltaTime;
            joints[1].distance -= forcaPuxar * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            AtivarCordao();
        }
        RenderLine();
    }
    void AtivarCordao()
    {
        for (int i = 0; i < joints.Count; i++)
        {
            joints[i].enabled = !joints[i].enabled;
        }
        joints[0].distance = DistanciaEntreJogadores() - 2;
        joints[1].distance = DistanciaEntreJogadores() - 2;
        if (noCordaoPlayer1.isKinematic)
        {
            noCordaoPlayer1.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            noCordaoPlayer1.bodyType = RigidbodyType2D.Kinematic;
        }
        if (noCordaoPlayer2.isKinematic)
        {
            noCordaoPlayer2.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            noCordaoPlayer2.bodyType = RigidbodyType2D.Kinematic;
        }
    }
    float DistanciaEntreJogadores()
    {
        return Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Player2").transform.position);
    }
    void RenderLine()
    {
        lr.SetPosition(0, player1.transform.position);
        lr.SetPosition(1, player2.transform.position);
    }
}
