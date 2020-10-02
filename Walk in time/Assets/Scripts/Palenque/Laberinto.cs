using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laberinto : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Wall")
        {
            player.transform.position = new Vector3(-8.97f, 1f, 4.62f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Finish")
        {
            Debug.Log("meta");
        }
    }
}
