using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSuicida : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(gameObject);
        }
    }
}
