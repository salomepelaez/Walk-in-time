using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;

    Manager manager;

    void Start()
    {
        speed = 3f;
        manager = Manager.Instance;
    }

    public void Update()
    {
        if(manager.isMoving == true)
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }
    } 
}
