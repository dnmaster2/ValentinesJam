using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 ajuste = new Vector3(0,0,-10);
    public float zoomMinimo = 3f, zoomMaximo = 10f, limiteZoom = 18f;
    Vector3 velocity;
    float smoothTime = .2f;
    Camera cam;
    bool gameOver;
    public GameObject gameOverPrefab;

    //Load
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    //Procura os dois jogadores
    private void Start()
    {
        targets.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
        targets.Add(GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>());
    }
    void LateUpdate()
    {
        //Se algum dos targets for nulo, ele o remove da lista
        foreach(Transform target in targets)
        {
            if(target == null)
            {
                targets.Remove(target);
            }
        }
        //Se for menor que 2, provavelmente um morreu e o jogo acabou.
        if (targets.Count < 2)
        {
            gameOverPrefab.SetActive(true);
        }
        //Comandos da camera
        if (!gameOver)
        {
            //Smoothdamp para movimento suave, usando um calculo do ponto central entre os dois players 
            transform.position = Vector3.SmoothDamp(transform.position, GetCenterPoint() + ajuste, ref velocity, smoothTime);
            //Dois lerps para interpolar o zoom maximo e minimo da camera com um limitador
            float actualZoom = Mathf.Lerp(zoomMinimo, zoomMaximo, GetDistancePoint() / limiteZoom);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, actualZoom, Time.deltaTime);
        }
        else
        {
            //Em caso de game over, ele retorna para um dos players e fixa o zoom
            cam.orthographicSize = 5f;
            transform.position = targets[0].position;
        }
        
    }

    Vector3 GetCenterPoint()
    {
        //Faz um bound entre os jogadores
        Bounds bound = new Bounds(targets[0].position, Vector2.zero);
        foreach (Transform target in targets)
        {
            bound.Encapsulate(target.position);
        }
        //retorna o ponto central do bound
        return bound.center;
    }

    float GetDistancePoint()
    {
        //Faz um bound entre os jogadores
        Bounds bound = new Bounds(targets[0].position, Vector2.zero);
        foreach (Transform target in targets)
        {
            bound.Encapsulate(target.position);
        }
        //retorna a distancia do bound
        return bound.size.x;
    }
}
