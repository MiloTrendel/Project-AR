using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMInventory : GMBaseState
{
    public GMInventory(GameStateContext context, GameStateManager.EGameStates key) : base(context, key)
    {
        GameStateContext Context = context;
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
        Debug.Log("DEBUG functon called");
        NextStateKey = GameStateManager.EGameStates.Walk;
    }
}
