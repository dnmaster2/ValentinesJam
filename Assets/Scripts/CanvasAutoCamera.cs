using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAutoCamera : MonoBehaviour
{
    void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
