using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAutoCamera : MonoBehaviour
{
    void Awake()
    {
        //coloca a camera do canvas como sendo a camera q ta na cena
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
