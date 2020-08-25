using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public bool isMoving;

    public GameObject options;
    public GameObject startGameButton;
    public GameObject optionsButton;

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
        SceneManager.LoadScene("Village");
    }

    public void OpenOptions()
    {
        options.SetActive(true);
        startGameButton.SetActive(false);
        optionsButton.SetActive(false);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
        startGameButton.SetActive(true);
        optionsButton.SetActive(true);
    }
}
