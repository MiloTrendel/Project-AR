using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMShow : GMBaseState
{
    public GMShow(GameStateManager.EGameStates key) : base(key)
    {
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
        GameStateContext.Player1.UpdateGenericPlayer();
        GameStateContext.Player2.UpdateGenericPlayer();
    }
    
    public override GameStateManager.EGameStates GetNextState()
    {
        return NextStateKey;
    }

    public override void ExitState()
    {
        if (isDebugging)
            Debug.Log("Exit Show");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG function called");
        NextStateKey = GameStateManager.EGameStates.MainMenu;
    }
}
