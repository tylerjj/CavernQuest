using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdventureGame : MonoBehaviour
{
    // Available within inspector.
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] State quitState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        //ManageState();
        ManageStateV2();
    }
    private void StartGame()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    private void ManageState()
    {

        var validInput = false;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            try
            {
                state = state.GetNextState(1);
                validInput = true;
            }
            catch (System.NullReferenceException)
            {
                Debug.Log("Error: Option not available.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            try
            {
                state = state.GetNextState(2);
                validInput = true;
            }
            catch (System.NullReferenceException)
            {
                Debug.Log("Error: Option not available.");
            }
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Quitting Game.");
            Application.Quit();
        }

        if (validInput)
        {
            textComponent.text = state.GetStateStory();
        }
    }


    /// <summary>
    ///  ManageStateV2 is the cleaner option than my original usage of
    ///  AdventureGame.ManageState() and State.getNextState(int index).
    ///  
    /// The reason it is cleaner is because it allows me to iterate
    /// through the keycodes. This was an issue I was aware of 
    /// earlier on, but didn't know a proper solution for, so this
    /// is good to know.
    /// </summary>
    public void ManageStateV2()
    {
        var nextStates = state.GetNextStates();
        for (int i = 0; i < nextStates.Length; i++)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha1 + i)) ||
                    (Input.GetKeyDown(KeyCode.Keypad1 + i)))
            {
                state = nextStates[i];
                textComponent.text = state.GetStateStory();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                state = quitState;
                textComponent.text = state.GetStateStory();
                Debug.Log("Quitting Game.");
                Application.Quit();
            }
        }
    }
 }

