using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum State
    {
        None,
        Spying,
        RunningAway
    };

    public State mState = State.None;

    public List<GameObject> references;
    public List<GameObject> pointReference;

    public TextMeshProUGUI attemptsText;

    public int contador;
    public int wrongChoices;

    public bool rightChoice;
    public bool wrongChoice;

    public void Awake()
    {
        Instance = this;
    }
     
    public int CountMatches(List<GameObject> required, List<GameObject> taken)
    {
        int numMatches = 0;
        int idx = 0;

        while( idx < required.Count && idx < taken.Count )
        {
            if( required[idx] == taken[idx] )
            {
                numMatches++;
                idx++;
            }
            else
            {
                break;
            }
        }

        return numMatches;
    }

    public void Update()
    {
        if(mState == State.RunningAway)
        {
            Debug.Log("miau");
            CheckPattern();
        }
    }

    public void CheckPattern()
    {
        int numMatches = CountMatches(references, pointReference);
        if( numMatches == references.Count )
        {
            Debug.Log("muy bien");
        }
    }
}
