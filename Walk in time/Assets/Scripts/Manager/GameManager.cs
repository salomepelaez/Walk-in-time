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
    
    public void Update()
    {
        if(mState == State.RunningAway)
        {
            //Debug.Log("miau");
            
        }

        //CheckPattern();
    }

    public bool CompareList(List<GameObject> required, List<GameObject> taken)
    {
        if (required == null || taken == null || required.Count != taken.Count)
        return false;

        if (required.Count == 0)
            return true;

        Dictionary<GameObject, int> lookUp = new Dictionary<GameObject, int>();
        
        for(int i = 0; i < required.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(required[i], out count))
            {
                lookUp.Add(required[i], 1);
                continue;
            }
            lookUp[required[i]] = count + 1;
        }
        for (int i = 0; i < taken.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(taken[i], out count))
            {
                return false;
            }
            
            count--;
            if (count <= 0)
                lookUp.Remove(taken[i]);
            else
                lookUp[taken[i]] = count;
        }

        return lookUp.Count == 0;
    }

    /*public int CountMatches(List<GameObject> required, List<GameObject> taken)
    {
        int numMatches = 0;
        int idx = 0;

        while( idx < required.Count && idx < taken.Count )
        {
            if( required[idx] == taken[idx] )
            {
                numMatches = numMatches + 1;
                idx = idx + 1;
            }
            else
            {
                break;
            }
        }

        Debug.Log(numMatches);

        return numMatches;
    }

    public void CheckPattern()
    {
        if(mState == State.RunningAway)
        {
            int numMatches = CountMatches(references, pointReference);
            if( numMatches == references.Count )
            {
                Debug.Log("muy bien");
            }
        }
    }*/
}
