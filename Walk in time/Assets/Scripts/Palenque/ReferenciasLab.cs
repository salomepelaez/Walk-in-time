using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenciasLab : MonoBehaviour
{
    GameManager manager;

    public void Start()
    {
        manager = GameManager.Instance;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Laberinto>() != null)
        {
            Debug.Log("Los puntos funcionan");
            manager.references.Add(this.gameObject);
        }
    }
}
