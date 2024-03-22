using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class GMWalk : GMBaseState
{
    public GMWalk(GameStateManager.EGameStates key) : base(key)
    {
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
        return NextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit Walk");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG function called");
        NextStateKey = GameStateManager.EGameStates.Show;
    }
}
