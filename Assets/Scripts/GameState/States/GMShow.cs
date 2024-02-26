using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMShow : GMBaseState
{
    public GMShow(GameStateContext context, GameStateManager.EGameStates key) : base(context, key)
    {
        GameStateContext Context = context;
    }

    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter Show");
    }

    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update Show");
    }
    
    public override GameStateManager.EGameStates GetNextState()
    {
        return nextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit Show");
        nextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG functon called");
        nextStateKey = GameStateManager.EGameStates.MainMenu;
    }
}
