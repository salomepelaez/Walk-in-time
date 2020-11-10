using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenciasLab : MonoBehaviour
{
    GameManager manager;

    public int id;

    public void Start()
    {
        manager = GameManager.Instance;
        manager.mState = GameManager.State.Spying;
    }

    public void Update()
    {
        if(manager.mState == GameManager.State.Spying &&  manager.references.Count == 7)
            manager.mState = GameManager.State.RunningAway;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Laberinto>() != null)
        {
            Debug.Log("Los puntos funcionan");
            //manager.references.Add(this.gameObject);
            manager._pR.AddReference(this.gameObject);
        }
    }
}
