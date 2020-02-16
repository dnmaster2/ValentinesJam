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

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        targets.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
        targets.Add(GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>());
    }
    void LateUpdate()
    {
        foreach(Transform target in targets)
        {
            if(target == null)
            {
                targets.Remove(target);
            }
        }
        print(targets.Count);
        if (targets.Count < 2)
        {
            gameOverPrefab.SetActive(true);
        }
        if (!gameOver)
        {
            transform.position = Vector3.SmoothDamp(transform.position, GetCenterPoint() + ajuste, ref velocity, smoothTime);
            float actualZoom = Mathf.Lerp(zoomMinimo, zoomMaximo, GetDistancePoint() / limiteZoom);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, actualZoom, Time.deltaTime);
        }
        else
        {
            cam.orthographicSize = 5f;
            transform.position = targets[0].position;
        }
        
    }

    Vector3 GetCenterPoint()
    {
        Bounds bound = new Bounds(targets[0].position, Vector2.zero);
        foreach (Transform target in targets)
        {
            bound.Encapsulate(target.position);
        }
        return bound.center;
    }

    float GetDistancePoint()
    {
        Bounds bound = new Bounds(targets[0].position, Vector2.zero);
        foreach (Transform target in targets)
        {
            bound.Encapsulate(target.position);
        }
        return bound.size.x;
    }
}
