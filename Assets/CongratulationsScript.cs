using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratulationsScript : MonoBehaviour
{
    public GameObject fadeout;
    public void NextLevel()
    {
        fadeout.SetActive(true);
    }
}
