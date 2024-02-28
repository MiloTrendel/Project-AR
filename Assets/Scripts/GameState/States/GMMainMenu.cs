using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GMMainMenu : GMMap
{
    public GMMainMenu(GameStateContext context, GameStateManager.EGameStates key) : base(context, key)
    {
        GameStateContext Context = context;
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
        return nextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit MainMenu");
        nextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG functon called");
        nextStateKey = GameStateManager.EGameStates.Map;
    }
}