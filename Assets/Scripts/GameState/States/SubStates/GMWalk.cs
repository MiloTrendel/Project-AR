using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GMWalk : GMMap
{
    public GMWalk(GameStateContext context, GameStateManager.EGameStates key) : base(context, key)
    {
        GameStateContext Context = context;
    }

    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter Walk");
    }

    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update Walk");
    }

    public override GameStateManager.EGameStates GetNextState()
    {
        return nextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit Walk");
        nextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG functon called");
        nextStateKey = GameStateManager.EGameStates.Show;
    }
}
