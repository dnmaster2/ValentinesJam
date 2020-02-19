using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skipper : MonoBehaviour
{
    public GameObject fadeout, canvasRef;
    public AnimationClip anim;
    void Start()
    {
        StartCoroutine(PulaCena());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Instantiate(fadeout, canvasRef.transform);
        }
    }

    IEnumerator PulaCena()
    {
        yield return new WaitForSeconds(anim.length);
        Instantiate(fadeout, canvasRef.transform);
    }
}
