using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GMMainMenu : GMBaseState
{
    public GMMainMenu(GameStateManager.EGameStates key) : base(key)
    {
    }
    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter MainMenu ");
    }
    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update MainMenu");
    }

    public override GameStateManager.EGameStates GetNextState()
    {
        return NextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit MainMenu");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG function called");
        NextStateKey = GameStateManager.EGameStates.Map;
    }
}