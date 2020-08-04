using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;

    Manager manager;

    void Start()
    {
        speed = 30f;
        manager = Manager.Instance;
    }

    public void Move()
    {
        if(manager.isMoving == true)
        {
            gameObject.transform.position += transform.forward * speed * Time.deltaTime;
        }
    } 
}
