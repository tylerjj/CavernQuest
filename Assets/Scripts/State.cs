using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string storyText;

    [SerializeField] State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public State GetNextState(int index)
    {

        if ((index - 1) < 0 || (index - 1) >= nextStates.Length)
        {
            throw new System.NullReferenceException();
        }
        else
        {
            return nextStates[index - 1];
        }
    }
}
