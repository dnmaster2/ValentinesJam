using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancarCorda : MonoBehaviour
{
    public GameObject Gancho;
    GameObject atualGancho;
    public bool cordaAtiva = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!cordaAtiva)
            {
                Vector2 destino = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                atualGancho = Instantiate(Gancho, transform.position, Quaternion.identity);
                atualGancho.GetComponent<Corda>().destino = destino;
                cordaAtiva = true;
            }
            else
            {
                Destroy(atualGancho);
                cordaAtiva = false;
            }
        }        
    }
}
