using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenciasLab : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Laberinto>() != null)
        {
            Debug.Log("Los puntos funcionan");
        }
    }
}
