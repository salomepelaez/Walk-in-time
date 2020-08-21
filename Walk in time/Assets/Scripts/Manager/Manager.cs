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
        StartCoroutine("NextScene");
    }

    public void CancelCall()
    {
        StopCoroutine("NextScene");
    }

    public void OptionsPanel()
    {
        StartCoroutine("OpenOptions");
    }

    public void CacelOptions()
    {
        StopCoroutine("OpenOptions");
    }

    public void CloseOptions()
    {
        StartCoroutine("CloseOptionsCoroutine");
    }

    public void CancelCloseOptions()
    {
        StopCoroutine("CloseOptionsCoroutine");
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Village");

        yield return new WaitForSeconds(3f);
    }

    IEnumerator OpenOptions()
    {
        yield return new WaitForSeconds(2f);

        options.SetActive(true);
        startGameButton.SetActive(false);
        optionsButton.SetActive(false);
    }

    IEnumerator CloseOptionsCoroutine()
    {
        yield return new WaitForSeconds(2f);

        options.SetActive(false);
        startGameButton.SetActive(true);
        optionsButton.SetActive(true);
    }
}
