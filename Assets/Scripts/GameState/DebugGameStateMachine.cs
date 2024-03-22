using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameStateMachine : MonoBehaviour
{
    public GameStateManager StateManager;
    [SerializeField]
    private KeyCode debugNextStateKeyCode;

    [SerializeField]
    private KeyCode toggleDebugKeyCode;

    void Update()
    {
        if (Input.GetKeyDown(debugNextStateKeyCode))
            StateManager.DebugNextStateIterate();

        if (Input.GetKeyDown(toggleDebugKeyCode))
            StateManager.ToggleDebug();
    }
}
