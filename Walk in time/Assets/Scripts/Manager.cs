using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public bool isMoving;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        isMoving = false;
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    public void LoadVillage()
    {
        StartCoroutine("NextScene");
    }

    public void CancelCall()
    {
        StopCoroutine("NextScene");
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Village");

        yield return new WaitForSeconds(3f);
    }
}
