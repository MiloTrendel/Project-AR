using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMInventory : GMBaseState
{
    public GMInventory(GameStateManager.EGameStates key) : base(key)
    {
    }

    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter Inventory");
    }

    public override void UpdateState()
    {
        if (isDebugging)
            Debug.Log("Update Inventory");
    }

    public override GameStateManager.EGameStates GetNextState()
    {
        return NextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit Inventory");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG function called");
        NextStateKey = GameStateManager.EGameStates.Walk;
    }
}
