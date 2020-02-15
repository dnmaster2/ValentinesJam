using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 ajuste;
    Vector3 velocity;
    float smoothTime = .5f;

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, GetCenterPoint() + ajuste, ref velocity, smoothTime);

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
}
