using UnityEngine;

public class GMInventory : GMBaseState
{
    private GameStateManager GSManager;
    public GMInventory(GameStateManager.EGameStates key, GameStateManager GSManager) : base(key)
    {
        this.GSManager = GSManager;
    }

    public override void EnterState()
    {
        if (isDebugging)
            Debug.Log("Enter Inventory");

        foreach (GameObject go in GSManager.Inventory)
        {
            go.SetActive(true);
        }
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
        foreach (GameObject go in GSManager.Inventory)
        {
            go.SetActive(false);
        }

        if (isDebugging)
            Debug.Log("Exit Inventory");
        NextStateKey = StateKey;
    }

    public override void DebugNextStateIterate()
    {
        Debug.Log("DEBUG function called");
        NextStateKey = GameStateManager.EGameStates.Pause;
    }
}
