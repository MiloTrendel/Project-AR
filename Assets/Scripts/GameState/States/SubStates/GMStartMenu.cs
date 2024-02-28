using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GMStartMenu : GMBaseState
{
    public GMStartMenu(GameStateContext context, GameStateManager.EGameStates key) : base(context, key)
    {
        GameStateContext Context = context;
    }

    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter StartMenu");
    }

    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update StartMenu");
    }

    public override GameStateManager.EGameStates GetNextState()
    {
        return NextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit StartMenu");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG functon called");
        NextStateKey = GameStateManager.EGameStates.ShowAR;
    }
}
