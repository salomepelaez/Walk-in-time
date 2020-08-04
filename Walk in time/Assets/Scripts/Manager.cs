using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public bool isMoving;

    public void Awake()
    {
        Instance = this;
    }

    public void start()
    {
        isMoving = false;
    }

    public void StartMoving()
    {
        isMoving = true;
    }
}
